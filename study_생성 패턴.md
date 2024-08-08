# 디자인 패턴

게임을 비롯한 소프트웨어 개발 과정에서 반복적으로 보이는 유사한 구조의 설계 목표가 보인다. 이런 목표를 해결하다가 어떠한 패턴화된 해결 방안, 설계 구조가 나타나게 되고 이러한 설계 구조가 패턴화 된 것이 디자인 패턴이다.

## 생성 패턴

클래스의 생성 과정이나 생성 규칙 등에 적용할 수 있는 디자인 패턴들이다.

### 팩토리 패턴

특정 클래스 계통의 생성을 일임하는 팩토리 클래스를 두는 설계 방법이다.  
예를 들어 몬스터 클래스의 자식으로 슬라임, 고블린, 골렘이 있고 세 종류의 몬스터는 또 다른 스텟과 이미지를 사용하는 변종이 있는 상황을 생각하자. 몬스터 팩토리는 적절한 매개변수를 받아 원본 몬스터 혹은 멤버 변수가 수정된 변종을 반환한다.

의사코드

```C#
public class MonsterFactory
{
    public static Monster Instantiate(Category c, int variant = 0)
    {
        switch(c)
        {
            case Category:Slime:
            {
                ...variant에 따라 초기화 진행...
                return slime;
            }
            case Category:Goblin:
            {
                ...variant에 따라 초기화 진행...
                return goblin;
            }
            case Category:Golem:
            {
                ...variant에 따라 초기화 진행...
                return golem;
            }
            default:
                ...에러 출력...
                return null;
        }
    }
}
```

초기화를 위해 외부 데이터를 읽어오는 등의 작업을 팩토리 클래스에게 일임하는 것으로 단일 클래스 단일 수행 원칙을 지킬 수 있다. 또한 데이터 시트 등을 통한 타 직군과의 협업을 유연하게 한다.

### 빌더 패턴

하나의 클래스에 생성시 선택 가능한 옵션이 너무 많다면 생성자를 통한 생성이 가독성이 떨어지며 난잡해지고 반복해서 사용하기 불편해진다.

```C#
void CreateGoblinGroup()
{
    // 어느 인자가 어느 자리로 들어가는지 파악하기도 힘들다...
    monsters.Add(new Goblin("고블린 샤먼", new Wand(), new SpellBook(), new Necklace()));
    monsters.Add(new Goblin("고블린 투척수", new ThrowStone()));
    monsters.Add(new Goblin("고블린 투척수", new ThrowStone()));
    monsters.Add(new Goblin("고블린 싸움꾼", null, null, new RaggedCloth()));
    monsters.Add(new Goblin("고블린 싸움꾼", null, null, new RaggedCloth()));
    monsters.Add(new Goblin("고블린 싸움꾼", new Knuckle(), null, new RaggedCloth()));
}
```

```C#
public class Goblin : Monster
{
    public Goblin(string name = "고블린", Weapon? rightHand = null, Weapon? leftHand = null, Armor? armor = null)
    {
        ...
    }
    ...
}
```

이런 경우 따로 빌더를 두어서 기본값 사용을 유연하게 하고 부품을 갈아끼우는 식의 생성을 용이하게 할 수 있다.

```C#
void CreateGoblinGroup()
{
    GoblinBuilder gb = new GoblinBuilder();
    
    gb.SetName("고블린 샤먼")
        .SetRightHand(new Wand())
        .SetLeftHand(new SpellBook())
        .SetArmor(new Necklace());
    monsters.Add(gb.Build());

    gb.Clear()
        .SetName("고블린 투척수")
        .SetRightHand(new ThrowStone());
    monsters.Add(gb.Build());
    monsters.Add(gb.Build());

    gb.Clear()
        .SetName("고블린 싸움꾼");
    monsters.Add(gb.Build());
    monsters.Add(gb.Build());
    gb.SetRightHand(new Knuckle()); // 일부만 변경하는 경우
    monsters.Add(gb.Build());
}
```

```C#
public class GoblinBuilder
{
    public GoblinBuilder Clear()
    {
        ..."고블린", null등의 기본값으로 초기화 진행...
        return this;
    }

    public GoblinBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    ...
    
    public Gobline Build()
    {
        return new Gobline(name, rightHand?.Clone(), leftHand?.Clone(), armor?.Clone());
    }
}
```

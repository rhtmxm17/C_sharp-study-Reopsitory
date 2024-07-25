# 추가적인 C# 문법

## 확장 메서드

기존의 클래스룰 직접 수정하지 않고 메서드를 추가해서 기능을 추가하는 방법이다.

### 사용 방법

static 메서드에 첫번째 인자로 this 키워드와 함께 해당 타입을 넣어서 만든다.

```C#
public static class Extension
{
    public static void MyExtensionFunc(this int value) { }
    public static void AnotherExtensionFunc(this OtherClass otherClass, float value) { }
}

public class Program
{
    static void ExtensionTest()
    {
        int a = 10;

        // 두가지 호출 방법 모두 가능하며 완전히 같다
        a.MyExtensionFunc();
        Extension.MyExtensionFunc(a);
    }
}
```

## 프로퍼티

### get set

직접 Getter와 Setter 작성을 간편하게 하는 문법이다.  
Getter와 Setter를 직접 작성한다면...

```C#
public class Program
{
    void GetSetTest()
    {
        Character character = new();
        character.SetHp(10);
        Console.Write(character.GetHp());
    }
}

public class Character
{
    private int hp;

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int hp)
    {
        if(hp < 0)
            hp = 0;
        
        this.hp = hp;
    }
}
```

프로퍼티 문법을 적용한다면...

```C#
public class Program
{
    void GetSetTest()
    {
        Character character = new();
        character.Hp = 10;
        Console.Write(character.Hp);
    }
}

public class Character
{
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            if(value < 0)
                value = 0;
            
            hp = value;
        }
    }

    public int Ap { get; private set; }
}
```

실제 동작은 같지만 사용시 멤버 변수와 비슷한 문법을 사용할 수 있기 때문에 더 직관적이다.

### 단순한 함수 치환

```C#
public class Character
{
    private float criticalDamageRate;
    private float attackStatus;

    // 아래 세 내용의 기능은 같고
    // 세번째만 호출 방법이 변수와 유사하다
    public float GetCriticalDamage()
    {
        return attackStatus * criticalDamageRate;
    }

    public float CriticalDamage() => attackStatus * criticalDamageRate;
    public float CriticalDamage2 => attackStatus * criticalDamageRate;
}
```

## 연산자 재정의(Operator Overloading)

```C#
public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // 연산자 재정의
    public static Point operator+(Point a, Point b)
    {
        return new Point(a.x + b.x, a.y + b.y);
    }
}

public class Program
{
    void OperatorOverloading()
    {
        Point p1 = new(2, 5);
        Point p2 = new(6, 1);
        Point p3 = p1 + p2; // x = 8, y = 6
    }
}
```

위의 예는 두 Point 구조체간의 + 연산을 재정의한 것이다. 자주 쓰는 자료형이 특정 연산자를 통한 사용이 직관적이고 자연스러우면 정의해주면 쓰기 좋다.

## null 조건 연산자(?.)

연산자 앞의 것이 null이 아니라면 뒤의 내용까지 수행하는 연산자이다.
null이라면 그대로 null로 취급한다.

```C#
static void NullCheckPrintHp(Character? character)
{
    Console.WriteLine(character?.Hp);
}

static void Test()
{
    Character? character = null;
    NullCheckPrintHp(character); // Console.WriteLine에 null이 들어가서 줄바꿈만 일어남

    character = new Character();
    NullCheckPrintHp(character); // 0 출력
}
```

## 그외

삼항 연산자(` ? : `)와 null 병합 연산자(`??`)가 있지만 직관성을 떨어뜨리는 정도에 비해 `?.`만큼 편리하지도 않아 자주 쓰이지 않는다.

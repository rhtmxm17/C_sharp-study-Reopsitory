# delegate 형식

함수를 등록해 둘 수 있는 자료형

## delegate 사용

### 정의하기

`delegate` `함수 반환형` `델리게이트 자료형` `함수 매개변수들`;

```C#
public delegate bool MyDelegate(int x, int y);
```

### 인스턴스 생성

`델리게이트 자료형` `변수명`

```C#
MyDelegate myDel;
```

### 사용례

```C#
bool LeftIsBigger(int left, int right)
{
    return left > right;
}

// 매개변수와 반환형이 정의된 것과 일치하는 함수만 가능
myDel = LeftIsBigger;
myDel?.Invoke(3, 6); // return false
```

## 제네릭 델리게이트

미리 정의되어있는 일반화 델리게이트  
매개변수 목록과 반환값을 지정하는 `Func`와  
매개변수 목록만 지정하는 `Action`이 있다  (`void`가 자료형이 아니기 때문에 `Func<void>`는 불가능)

```C#
// int와 float를 받아서 double을 반환하는 delegate
Func<int, float, double> func;
func = MyFunction;

// int와 bool을 받는 반환값이 없는 delegate
Action<int, bool> action;
action = MyAction;

double MyFunction(int a, float b) { return 0.0; }
void MyAction(int a, bool b) { }
```

## 게임에서?

특정 상황이 발생했을때 일어나야 하는 일에 관한 처리를 직관적으로 할 수 있다.
아래는 플레이어가 공격 받았을 경우 현재 상태에 따라 피격 또는 반격을 하는 예시를 생각해보았다.

```C#
public class Player
{
    private Action<Skill, Character> onHitted;

    public void TakeAttack(Skill atk, Character attacker)
    {
        onHitted(atk, attacker);
    }

    public void BeginCounter()
    {
        onHitted = CounterAttack;
    }

    public void EndCounter()
    {
        onHitted = TakeDamage;
    }

    private void TakeDamage(Skill atk, Character attacker) { }
    private void CounterAttack(Skill takenAtk, Character attacker) { }
}
public class Skill { }
public class Character { }
```

여기서는 단순하게 onHitted 델리게이트의 내용을 치환했지만, 필요에 따라 체인
구성이나 제거하는 것으로 피격시 발동하는 버프 등의 처리 또한 가능할 것이다.

## 지정자(Specifier)

매개변수로 `delegate`를 전달할 수 있다는 점을 활용한 구성. 미완성의 함수를
`delegate`를 넣어서 완성시키는 것 처럼, 받은 `delegate`에 따라 다른 동작을 수행하는 것이다.  
함수 내에서 매개변수로 받은 `delegate`를 호출하는 식으로 작동한다.

가장 `compare`에 해당하는 값을 반환하는 예:

```C#
void Sample()
{
    int[] intArray = { 1, 3, 5, 7 };

    int biggest = Most(intArray, Bigger); // 7 반환
    int smallest = Most(intArray, Less); // 1 반환
}

int Most(int[] array, Func<int, int, bool> compare)
{
    // 예외
    if (array.Length == 0)
        return 0;
    if (array.Length == 1)
        return array[0];

    int most = array[0];
    for (int i = 0; i < array.Length; i++)
    {
        // 대상 내용(array[i])이 기존값(most)보다 더
        // 기준(compare)을 만족한다면 대체
        if (compare(array[i], most))
            most = array[i];
    }
    return most;
}

bool Bigger(int left, int right)
{
    return left > right;
}

bool Less(int left, int right)
{
    return left < right;
}
```

## 실험

등록할 함수에 기본 매개변수가 있다면?

## 이벤트

특정 사건이 발생했다는 사실을 다른 객체에게 전달하는 방식의 구성. `event` 키워드를 사용해서 기능의 일부를 제한한 `delegate`를 사용해서 만든다.

### event 키워드

델리게이트 변수의 한정된 기능만을 클래스 외부에서 사용할 수 있도록 하는 키워드

```C#
public class MyClass
{
    // event 키워드 사용
    public event Action MyEvent;
    
    public void Trigger()
    {
        MyEvent?.Invoke();
    }
}

public class OtherClass
{
    static void EventFunction() { }

    public static void Main()
    {
        MyClass eventHolder = new();

        // 추가 가능
        eventHolder.MyEvent += EventFunction;
        
        // 제거 가능
        eventHolder.MyEvent -= EventFunction;
        
        // 대입 불가능
        // eventHolder.MyEvent = EventFunction;
        
        // 실행 불가능
        // eventHolder.MyEvent.Invoke();
    }
}
```

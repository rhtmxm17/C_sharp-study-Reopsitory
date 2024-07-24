## 제네릭의 장점 및 활용 방안

### 제네릭의 편리함

다양한 타입에 대해 동일한 동작을 수행할 때 제네릭을 활용해 간단하게 일반화 할 수 있다.   
메소드 오버로딩을 통한 일반화를 시도할 경우 사용할 수 있는 타입의 수 만큼 반복적으로
코드를 작성해야하며 새로운 struct와 같은 사용자 정의 타입이 생길 때 마다 같은 작업이 필요해진다.

### 형식 제약 조건(where)

```C#
public void swap<T>(ref T a, ref T b)
{
	T temp = a;
	a = b;
	b = temp;
}
```
이 코드와 같이 제네릭을 사용할 경우 T의 자리에 어떠한 자료형도 들어올 수가 있다. 
위의 예시의 경우 T의 자리에 참조 변수가 들어올 경우 두 참조 변수가 가리키는 메모리의
내용물이 교환되는 것이 아니라 참조 변수가 어느 메모리를 가리키는지가 교환된다.   
이때 일어나는 일을 C++식으로 이해해보았다.
```C++
public class MyClass{ }
void swap(MyClass*& a, MyClass*& b)
{
	MyClass* temp = a;
	a = b;
	b = temp;
}
```
이것이 충분히 고려하고 의도된 사항이라면 괜찮을 수 있으나, 그렇지 않다면 이러한 상황을
`where` 키워드로 방지할 수 있다.   
(사실 의도했더라도 함수가 의미하는 바가 모호하다는 것 자체가 별로 괜찮아보이지는 않는다)

```C#
public void swap<T>(ref T a, ref T b) where T : struct
{
	T temp = a;
	a = b;
	b = temp;
}
```
이 swap()함수는 값 형식의 변수에만 사용할 수 있다.

### 제네릭이 박싱/언박싱을 줄여주는 경우

제네릭은 각 타입에 맞춰 < >안에 지정한 타입명으로 대체된 함수/클래스를 만들어주는 식으로
작동한다. 따라서 원래라면 값 타입 -> 참조 타입 형변환이 일어나야 할 함수를 제네릭을 사용해
구현하면 애당초 형변환이 일어나지 않아 박싱/언박싱을 줄일 수 있다.   

아래는 인터페이스까지 공부한 후에 이해한 내용이다.   
인터페이스 변수는 본래 참조 변수이다. 값 변수인 구조체가 인터페이스를 구현했고, 인터페이스
변수를 통해 해당 구조체를 사용할 경우 구조체를 박싱해 인터페이스 변수로 만든 뒤 지정된
동작을 수행하는 과정을 거치게 된다.
```C#
public interface IDoubleable
{
    public void Doubleself();
}

public struct Point : IDoubleable
{
    int x;
    int y;

    public void Doubleself()
    {
        x *= 2;
        y *= 2;
    }
}

public void DoDouble(IDoubleable val)
{
    val.Doubleself();
}
```
이 경우 DoDouble()의 인자로 Point형 변수를 넣어주면 IDoubleable 타입으로 박싱이 일어난다.
(DoDouble의 인자로 ref IDoubleable를 받는 시도를 해봤지만 이 함수는 ref Point를 넣을 수 없었다)

```
public static void DoDoubleGeneric<T>(ref T val) where T : IDoubleable
{
    val.Doubleself();
}
```
하지만 제네릭을 사용해 아예 Point형 변수를 사용하는 함수로 만들어 줄 경우 박싱/언박싱
없이 인터페이스를 사용할 수 있다.

`Int32`와 같이 `System`에 정의된 struct를 보면 인터페이스와 제네릭을 잔뜩 달고있는데,
이러한 방식과 그 연장을 극한으로 사용하지 않았을까?

테스트한 코드: [BoxingStudy.cs](./BoxingStudy.cs)

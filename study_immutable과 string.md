# immutable과 string

## string의 작동 방식

C# string의 동작 방식은 여타 클래스와 비교해 매우 특이하다.
실제 구현은 class이지만 내용 변경을 시도할 경우 변경한 내용의 복사본을 만들어서 해당 복사본으로 참조를 이동하기 때문에 마치 struct와 같은 체감을 준다. 한 string의 복사본을 변경해도 원본은 변하지 않는 것이다.

## immutable

결국 복사본이 생길 뿐 원본만큼은 변화가 없는 이러한 특징을 불변성(immutable)이라 한다.

## string 변경의 비용

이러한 작동 방식은 분명 처음 문자열을 직관적으로 다루는데에는 도움이 되겠지만, 대신 문자열을 아주 조금만 수정해도 전체를 복사해야만 한다.

```C#
string str = "";

for (char c = 'A'; c <= 'Z'; c++)
{
    str += c;
}

Console.WriteLine($"A to Z: {str}");
```

A부터 Z까지의 문자열을 만드는 이 간단한 프로그램은 알파벳의 수 만큼 str 전체를 복사한다는 문제가 있다. 게임에서는 대사 텍스트를 대화하듯 한글자씩 추가해가며 출력하는 등의 기능에서 이런 상황이 발생할 것으로 예상할 수 있다.

## StringBuilder

이러한 비용 낭비를 방지하기 위한 방법으로 문자열을 class답게 작동시키는 [StringBuilder](https://learn.microsoft.com/ko-kr/dotnet/api/system.text.stringbuilder?view=net-8.0) 클래스를 사용할 수 있다. 기본적으로는 배열 형태로 관리중인 공간 내에서 문자열을 더하고 바꾸고 빼는 클래스이다.
할당된 메모리 크기(`Capacity`)를 초과하는 경우에만 새로 충분히 큰 공간을 할당받고 전체를 복사한다.

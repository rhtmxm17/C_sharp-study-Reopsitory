## interface

### 다중 상속(불가능)

다중 상속이 가능하다면 다이아몬드 상속이 발생할 경우의 처리가 난해해진다.
조부모의 멤버 변수를 참조할 경우 어느쪽 부모에서의 상속한 의미로서 사용하는지
난해한 점이나 한쪽 부모 클래스가 조부모 클래스의 내용을 변경한 것이 다른쪽 부모
클래스에서 예상치 못한 결과를 야기하는 등의 문제가 발생할 수 있기 때문이다.   
하지만 클래스 만으로는 아이템의 기능 A, B, C가 있을 때 A와 B가 가능한 클래스,
B와 C가 가능한 아이템 클래스가 있을 때 다중 상속 없이 이러한 관계를 상속으로
구현하기 어렵다.

### interface 키워드

_class_ can _interface_

클래스가 무엇이 가능한지를 의미하는, abstract 클래스와 유사하게 동작하는 기능이다.   
아까의 예시에서, 기능 A, B, C가 가능함을 각각 인터페이스 IA, IB, IC로 정의하면
A와 B가 가능한 아이템은 IA, IB 인터페이스를 구현하고 B와 C가 가능한 아이템은
IB, IC 인터페이스를 구현한다.   
이를 클래스의 선언부만 적으면
```C#
public class Item { }
public interface IConsumeable { }
public interface ISellable { }
public interface IEquipable { }
public class ItemCanAB : Item, IConsumeable, ISellable { }
public class ItemCanBC : Item, ISellable, IEquipable { }
```
이와 같은 형태가 된다

### interface의 사용

인터페이스는 어떠한 기능이 가능함을 의미하며, '가능한 기능'은 인터페이스에서 함수를 구현 없이
선언만 하는 것으로 정의한다. 인터페이스를 구현하는 클래스에서는 부모에서 abstract로 선언된
함수를 정의하듯 반드시 해당 내용을 구현해야 한다.

자식 클래스의 인스턴스를 부모 클래스의 타입으로 사용하듯이, 특정 인터페이스를 구현한 클래스는
그 인터페이스의 타입으로 사용할 수 있다. 예를들어 피격 가능 인터페이스를 구현한 몬스터와
파괴가능 물체를 피격 가능 타입으로 컬렉션에 담아서 공격 발생시 사용하는 식이다.

사실상 다중 상속시 발생할 수 있는 문제를 제약으로 차단한 추상 클래스.

-----------------

### 인터페이스의 활용 예시 상상해보기

포켓몬스터의 아이템을 클래스로 만들고 용도에 따른 인터페이스를 부여한다고 가정한다.
우선 생각 해볼만한 종류는 아래와 같다.
* 볼
* 상처약
* 버프 아이템
* 진화 아이템
* 기술 머신
* 배틀 도구
* 나무열매

트레이너가 가방에서 사용할 수 있는 도구는
* 상처약
* 진화 아이템
* 기술 머신
* 나무열매

트레이너가 배틀중에 사용할 수 있는 도구는
* 볼
* 상처약
* 버프 아이템
* 나무열매

포켓몬에게 지니게 해서 포켓몬이 스스로 사용하거나 효과를 발휘하는 도구는
* 배틀 도구
* 나무열매

이와 같이 상속만으로 기능을 분류하기에는 매우 난해하기 때문에 사용 방법에 따라
인터페이스를 적용하면 관리가 쉬워질 것 같다.

가방에서 사용할 수 있는 도구 `IBagUseable`   
배틀중에 사용할 수 있는 도구 `IBattleUseable`   
포켓몬이 스스로 사용하는 도구 `IMonsterUseable`   
* 볼 : `IBattleUseable`
* 상처약 : `IBagUseable`, `IBattleUseable`
* 버프 아이템 : `IBattleUseable`
* 진화 아이템 : `IBagUseable`
* 기술 머신 : `IBagUseable`
* 배틀 도구 : `IMonsterUseable`
* 나무열매 : `IBagUseable`, `IBattleUseable`, `IMonsterUseable`

/*

과제 1. 상속관계 구현하기
 
메탈슬러그의 총기 - 세부 분류 관계를 상속 관계로 표현
부모 클래스 Weapon

자식 클레스 HeavyMachinegun, RocketLauncher, FlameShot

공통적인 데이터로 이름, 최대 탄환, 현재 탄환을 갖고
공통적인 기능으로 발사, 잔탄확인, 총알 습득을 갖는다

하지만 발사, 총알 습득의 작동 방식이 각자 다르므로 이를 override로 재정의한다

-----------------------------------------------------

추상 클래스를 사용해 구현

'발사'는 기본 동작을 가질 수 있는 virtual로 선언하는 것으로
재정의가 가능하되 기본 동작을 사용할 수 있도록 하고
1. 완전히 재 정의
2. 기본 동작을 포함한 재 정의
3. 기본 동작 사용
의 세 가지 경우를 모두 시도했다

'총알 습득'은 반드시 구현해야 하는 abstract로 선언했다 

=====================================================

과제 2. 오버로딩과 오버라이딩

### 추상클래스의 정의

실제로 인스턴스를 만들지 않고 자식클래스를 만드는 틀이 되는 클래스
자식 클래스에서는 추상 메서드를 반드시 구현해야 한다


### 오버라이딩의 정의

virtual 키워드가 선언된 부모 클래스의 함수를 자식 클래스에서 override클래스와 함께 재정의해서 해당 클래스별로 새로운 동작으로 만드는것
오버라이드된 함수는 부모 클래스의 자료형으로 호출해도 해당 자식 클래스의 함수로 동작한다


### 오버로딩의 정의

같은 이름으로 다른 인자를 받는 메서드를 정의하는것


 */

namespace HW_30106_abstract
{
    public abstract class Weapon
    {
        private string name;
        protected int maxBullet;
        protected int curBullet;

        public Weapon(string name, int maxBullet)
        {
            this.name = name;
            this.maxBullet = maxBullet;
            this.curBullet = maxBullet;
        }

        public virtual void Shoot()
        {
            curBullet--;

            Console.Write($"{name} 발사");

            ExhaustionCheck();
        }

        protected void ExhaustionCheck()
        {
            if (curBullet <= 0)
                Console.WriteLine($"{name} 소진");
        }

        public abstract void GainAdditionalBullet();
    }

    public class HeavyMachinegun : Weapon
    {
        public HeavyMachinegun() : base("HeavyMachinegun", 200)
        {

        }

        public override void Shoot()
        {
            curBullet -= 4;

            for (int i = 0; i < 4; i++)
                ShootHM(i);

            ExhaustionCheck();
        }

        // 가상의 탄환 1개 발사 함수
        private void ShootHM(int shootPattern)
        {
            Console.Write($"HM발사{shootPattern}");
        }

        public override void GainAdditionalBullet()
        {
            curBullet += 100;
            if (curBullet > maxBullet)
                curBullet = maxBullet;
        }
    }

    public class RocketLauncher : Weapon
    {
        public RocketLauncher() : base("Rocket Launcher", 30)
        {

        }

        public override void Shoot()
        {
            // 로켓 런처 탄환이 맵에 2개 이상 있을경우 발사 불가
            if (CountBullets() >= 2)
                return;

            // 조건 만족시 기본 동작 수행
            base.Shoot();
        }

        // 가상의 맵에 존재하는 탄환 계수 함수
        private int CountBullets()
        {
            return 1;
        }

        public override void GainAdditionalBullet()
        {
            curBullet += 10;
            if (curBullet > maxBullet)
                curBullet = maxBullet;
        }
    }

    public class FlameShot : Weapon
    {
        public FlameShot() : base("Flame Shot", 30)
        {

        }

        // Shoot() 재정의 하지 않음으로 기본 동작 수행

        public override void GainAdditionalBullet()
        {
            curBullet += 10;
            if (curBullet > maxBullet)
                curBullet = maxBullet;
        }
    }
}

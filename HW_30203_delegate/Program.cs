namespace HW_30203_delegate
{
    internal class Program
    {
        public class Player
        {
            private Armor? curArmor;

            public void Equip(Armor armor)
            {
                Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
                curArmor = armor;
                
                curArmor.OnBreaked += UnEquip; // 추가한 내용
            }

            public void UnEquip()
            {
                if (curArmor == null)           //
                    return;                     //
                curArmor.OnBreaked -= UnEquip;  // 추가한 내용

                Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
                curArmor = null;
            }

            public void Hit()
            {
                // 채워넣은 함수 내용
                Console.WriteLine("플레이어 피격.");
                curArmor?.DecreaseDurability();
            }
        }

        public class Armor
        {
            public string name;
            private int durability;

            public event Action OnBreaked;

            public Armor(string name, int durability)
            {
                this.name = name;
                this.durability = durability;
            }

            public void DecreaseDurability()
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                // 채워넣은 함수 내용
                OnBreaked?.Invoke();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor ammor = new Armor("갑옷", 3);

            player.Equip(ammor);

            player.Hit();
            player.Hit();
            player.Hit();
        }
    }
}

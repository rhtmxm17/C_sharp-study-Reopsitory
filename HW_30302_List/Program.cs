/*

과제 1. 동적 인벤토리 구현하기

다음의 조건을 충족하는 인벤토리 시스템을 구현하시오
프로그램 시작 시 인벤토리는 빈 상태에서 시작한다.
프로그램이 구동되는 동안 입력마다 콘솔에 지속적으로 인벤토리의 상태를 표시한다
인벤토리는 최대 9개의 아이템을 가질 수 있다.
인벤토리는 빈칸 없이 앞부터 채워서 가진다
숫자키 0을 누르면 랜덤으로 아이템의 종류를 획득하고 인벤토리에 추가한다
숫자키 1~9를 누르면 해당하는 숫자의 아이템을 제거한다

 */

namespace HW_30302_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Inventory inventory = new();

            while (true)
            {
                // 출력 단계
                inventory.PrintContents();
                Console.WriteLine("0을 입력해 무작위 아이템 획득");
                Console.WriteLine("또는 제거할 아이템 번호 입력");

                // 입력 단계
                bool isNumber = false;
                int input = 0;
                while (isNumber == false)
                {
                    char key = Console.ReadKey(true).KeyChar;
                    if ('0' <= key && key <= '9')
                    {
                        isNumber = true;
                        input = key - '0';
                    }
                }

                // 수행 단계
                Console.Clear();

                if (input == 0)
                {
                    Item item = CreateRandomItem(random);
                    bool result = inventory.AddItem(item);
                    if (result)
                    {
                        Console.WriteLine("생성된 아이템을 가방에 넣었습니다.");
                    }
                    else
                    {
                        Console.WriteLine("가방이 가득찼습니다.");
                    }

                }
                else
                {
                    bool result = inventory.TakeOutItem(input - 1) is not null;
                    if (result)
                    {
                        Console.WriteLine($"{input}번 칸의 아이템을 버렸습니다.");
                    }
                    else
                    {
                        Console.WriteLine("비어있는 칸입니다.");
                    }
                }

                Console.WriteLine("=============================");
            }
        }

        static Item CreateRandomItem(Random source)
        {
            Item item;

            int randVal = source.Next(5);

            switch (randVal)
            {
                case 0:
                    item = new Potion() { Name = "상처치료약" };
                    break;
                case 1:
                    item = new Weapon() { Name = "아포칼립스 Type-Void 기어" };
                    break;
                case 2:
                    item = new Armor() { Name = "내한 팰 금속 갑옷" };
                    break;
                case 3:
                    item = new Accessory() { Name = "울부짖는 환상의 귀걸이" };
                    break;
                case 4:
                    item = new Food() { Name = "황금 사과" };
                    break;
                default:
                    throw new NotImplementedException();
            }
            return item;
        }

        public class Inventory
        {
            private const int inventorySize = 9;

            public Inventory()
            {
                items = new(inventorySize);
            }

            public void PrintContents()
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"[슬롯{i + 1}] {items[i].Name}");
                }
            }

            public bool AddItem(Item item)
            {
                if (items.Count >= inventorySize)
                    return false;

                items.Add(item);

                return true;
            }

            public Item? TakeOutItem(int index)
            {
                if (items.Count <= index)
                    return null;

                Item take = items[index];
                items.RemoveAt(index);

                return take;
            }

            // 인벤토리는 특정 위치에 대한 접근이 빈번할 것이기 때문에 List를 사용했다.
            private List<Item> items;
        }

        public class Item
        {
            public string Name { get; set; }
        }
        public class Potion : Item;
        public class Weapon : Item;
        public class Armor : Item;
        public class Accessory : Item;
        public class Food : Item;
    }
}

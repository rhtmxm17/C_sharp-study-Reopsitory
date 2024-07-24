namespace HW_30201_Generic
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new(10);

            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("체력 포션"));

            potionInventory.PrintItemNames();

            potionInventory.Remove();
            potionInventory.Remove();

            potionInventory.PrintItemNames();
        }
    }

    public abstract class Item
    {
        public string Name { get; private set; }
        public Item(string name)
        {
            Name = name;
        }
    }

    public class Potion : Item
    {
        public Potion(string name) : base(name) { }
    }

    // 제네릭에서 where키워드로 사용 가능한 형식을 제한하는 예시
    // T는 Item클래스임을 명시해서 Item 및 Item을 상속하는 키워드로 치환해서 사용 가능하다
    public class Inventory<T> where T : Item
    {
        private T?[] list;
        private int index;

        public Inventory(int size)
        {
            list = new T[size];
        }

        public void Add(T item)
        {
            if (index < list.Length)
            {
                list[index] = item;
                index++;
            }
        }

        public void Remove()
        {
            if (index > 0)
            {
                index--;
                list[index] = null;
            }
        }

        public void PrintItemNames()
        {
            Console.WriteLine($"아이템 목록: ");
            foreach (T? item in list)
            {
                if (item != null)
                {
                    // T가 Item 클래스 또는 Item을 상속한 클래스로 한정했으므로
                    // Name 필드가 존재하기 때문에 제네릭 내부에서 이와 같이
                    // 다른 자료형이었다면 사용할 수 없는 명칭이나 사용 방식도 쓸 수 있다
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}

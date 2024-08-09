namespace HW_40202_CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateGoblinGroup();

            //return;
            Console.WriteLine("******************");

            ItemFactory itemFactory = new("./가상의/데이터.경로");

            Item[] items = new Item[5];
            items[0] = itemFactory.Create(ItemType.Potion);
            items[1] = itemFactory.Create(ItemType.Food);
            items[2] = itemFactory.Create(ItemType.Weapon);
            items[3] = itemFactory.Create(ItemType.Potion, 1);
            items[4] = itemFactory.Create(ItemType.Potion, 2);

            foreach (Item item in items)
            {
                Console.WriteLine(item.Info());
            }

        }

        private static void CreateGoblinGroup()
        {
            List<Goblin> monsters = new();
            GoblinBuilder gb = new();

            gb.SetName("고블린 샤먼")
                .SetRightHand(new Weapon("완드"))
                .SetLeftHand(new Weapon("주문 책자"))
                .SetArmor(new Armor("목걸이"));
            monsters.Add(gb.Build());

            gb.Clear()
                .SetName("고블린 투척수")
                .SetRightHand(new Weapon("투석"));
            monsters.Add(gb.Build());
            monsters.Add(gb.Build());

            gb.Clear()
                .SetName("고블린 싸움꾼");
            monsters.Add(gb.Build());
            monsters.Add(gb.Build());

            gb.SetRightHand(new Weapon("너클")); // 일부만 변경하는 경우
            monsters.Add(gb.Build());

            foreach (var gob in monsters)
            {
                Console.WriteLine(gob.Info());
            }
        }
    }
}

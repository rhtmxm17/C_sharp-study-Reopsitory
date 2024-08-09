namespace HW_40202_CreationalPatterns
{
    // 가상의 이미지 클래스가 구현되어있다 가정
    public class Image
    {
        public Image(string name) { }
    }
    public enum ItemType { Potion, Weapon, Armor, Food }

    public class ItemFactory
    {

        struct PotionData
        {
            public string name;
            public int price;
            public Image img;
        }

        private PotionData[] potionTables;

        public ItemFactory(string dataPath)
        {
            // 실제로는 별도로 저장된 데이터를 읽어오게 될 것으로 생각된다
            potionTables = new PotionData[3];
            potionTables[0].name = "물약";
            potionTables[0].price = 10;
            potionTables[0].img = new Image("물약병.png");
            potionTables[1].name = "파란 물약";
            potionTables[1].price = 25;
            potionTables[1].img = new Image("파란물약병.png");
            potionTables[2].name = "빨간 물약";
            potionTables[2].price = 20;
            potionTables[2].img = new Image("빨간물약병.png");
        }

        public Item Create(ItemType type, int arg = 0)
        {
            switch (type)
            {
                case ItemType.Potion:
                    Potion potion = new Potion(potionTables[arg].name, potionTables[arg].price, potionTables[arg].img);
                    return potion;
                case ItemType.Weapon:
                    Weapon weapon = new Weapon();
                    return weapon;
                case ItemType.Armor:
                    Armor armor = new Armor();
                    return armor;
                case ItemType.Food:
                    Food food = new Food();
                    return food;
                default:
                    throw new ArgumentException();
            }
        }
    }
}

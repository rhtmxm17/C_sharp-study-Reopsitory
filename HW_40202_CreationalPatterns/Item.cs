namespace HW_40202_CreationalPatterns
{
    public abstract class Item
    {
        private string name;

        public Item() : this("이름 없는 아이템") { }

        public Item(string name)
        {
            this.name = name;
        }

        public Item(Item original)
        {
            this.name = original.name;
        }

        public virtual string Info()
        {
            return $"이름:{name}";
        }
    }

    public class Potion : Item
    {
        private int price;
        private Image img;

        public Potion(string name, int price, Image img) : base(name)
        {
            this.price = price;
            this.img = img;
        }
        public Potion(Potion original) : base(original)
        {
            this.price = original.price;
            this.img = original.img;
        }

        public override string Info()
        {
            string baseInfo = base.Info();

            return $"{baseInfo}, 가격:{price}";
        }
    }

    public class Weapon : Item
    {
        public Weapon() : base("무기") { }

        public Weapon(string name) : base(name) { }

        public Weapon(Weapon original) : base(original) { }
    }

    public class Armor : Item
    {
        public Armor() : base("방어구") { }

        public Armor(string name) : base(name) { }

        public Armor(Armor original) : base(original) { }
    }

    public class Food : Item
    {
        public Food() : base("음식") { }

        public Food(string name) : base(name) { }

        public Food(Food original) : base(original) { }
    }
}

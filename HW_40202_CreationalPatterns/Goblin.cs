namespace HW_40202_CreationalPatterns
{
    public class GoblinBuilder
    {
        public string Name { get; set; } = "고블린";
        public Weapon? RightHand { get; set; } = null;
        public Weapon? LeftHand { get; set; } = null;
        public Armor? Armor { get; set; } = null;

        public GoblinBuilder Clear()
        {
            Name = "고블린";
            RightHand = null;
            LeftHand = null;
            Armor = null;
            return this;
        }

        public GoblinBuilder SetName(string name)
        {
            Name = name;
            return this;
        }

        public GoblinBuilder SetRightHand(Weapon? rightHand)
        {
            RightHand = rightHand;
            return this;
        }

        public GoblinBuilder SetLeftHand(Weapon? leftHand)
        {
            LeftHand = leftHand;
            return this;
        }

        public GoblinBuilder SetArmor(Armor? armor)
        {
            Armor = armor;
            return this;
        }

        public Goblin Build()
        {
            Weapon? rh = null;
            Weapon? lh = null;
            Armor? am = null;

            if (RightHand != null)
                rh = new Weapon(RightHand);
            if (LeftHand != null)
                lh = new Weapon(LeftHand);
            if (Armor != null)
                am = new Armor(Armor);

            return new Goblin(Name, rh, lh, am);
        }
    }

    public class Goblin
    {
        public string Name { get; private set; }
        private Weapon? rightHand;
        private Weapon? leftHand;
        private Armor? armor;

        public Goblin(string name = "고블린", Weapon? rightHand = null, Weapon? leftHand = null, Armor? armor = null)
        {
            Name = name;
            this.rightHand = rightHand;
            this.leftHand = leftHand;
            this.armor = armor;
        }

        public string Info()
        {
            return $"이름: {Name}, 오른손Hash: {rightHand?.GetHashCode()}";
        }
    }
}

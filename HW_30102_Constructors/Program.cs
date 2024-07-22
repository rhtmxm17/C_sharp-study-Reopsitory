namespace HW_30102_Constructors
{
    internal class Program
    {
        class Monster
        {
            private int maxHp;
            private int hp;

            public Monster(int maxHp)
            {
                this.maxHp = maxHp;
                this.hp = maxHp;
            }

            public void WriteHp()
            {
                Console.Write($"HP: {hp, 3}/{maxHp, 3}");
            }
        }

        class Trainer
        {
            private string name;
            private Monster[] monsters;

            public Trainer(string name)
            {
                this.name = name;
                this.monsters = new Monster[6];
            }

            public bool NewMonster(int maxHp)
            {
                bool success = false;
                for (int i = 0; i < monsters.Length; i++)
                {
                    if (monsters[i] == null)
                    {
                        monsters[i] = new Monster(maxHp);
                        success = true;
                        break;
                    }
                }

                return success;
            }

            public void WriteSummary()
            {
                Console.WriteLine($"이름: {name}");
                for (int i = 0; i < monsters.Length; i++)
                {
                    Console.Write($"{i + 1}번 ");
                    if (monsters[i] == null)
                    {
                        Console.Write($"(비어있음)");
                    }
                    else
                    {
                        monsters[i].WriteHp();
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Trainer trainer = new Trainer("새내기 트레이너 A");

            trainer.NewMonster(10);
            trainer.NewMonster(100);
            trainer.NewMonster(33);

            trainer.WriteSummary();
            Console.WriteLine();

            trainer.NewMonster(722);
            trainer.NewMonster(617);
            trainer.NewMonster(1);
            trainer.NewMonster(12);

            trainer.WriteSummary();

        }
    }
}

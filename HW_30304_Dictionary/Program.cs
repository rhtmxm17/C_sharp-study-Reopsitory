namespace HW_30304_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Monster createByName = new("더시마사리");
            Monster? tryCreate = Monster.TryCreate("이상해씨");
            Monster? tryCreateIncorrect = Monster.TryCreate("없는이름"); // tryCreateIncorrect is null
            Monster createByIncorrectName = new("이것도없는이름"); // NullReferenceException
        }

        public class Monster
        {
            // 프로그램 시작시 초기화
            private static MonsterData s_data;
            static Monster()
            {
                s_data = new MonsterData();
            }

            public string Name { get; private set; }
            public int Number { get; private set; }
            public int Level { get; set; } = 1;

            // 반드시 인스턴스의 생성이 동반되므로
            // 잘못된 이름이 들어오면 예외처리가 어려워 보인다
            public Monster(string Name) : this(s_data[Name])
            {
                
            }

            // 잘못된 이름이 들어오면 null을 반환하도록 했지만
            // 이 함수 자체는 생성자가 아니라서 new 키워드 관련 기능 사용 불가
            // 바깥에서 null에 대한 처리가 필요
            public static Monster? TryCreate(string Name)
            {
                Monster? result = s_data[Name];

                if(result is null)
                    return null;

                return new Monster(result);
            }

            public Monster(Monster original)
            {
                this.Name = original.Name;
                this.Number = original.Number;
            }

            // 원본 생성을 위한 private로 닫힌 생성자
            private Monster(string Name, int Id)
            {
                this.Name = Name;
                this.Number = Id;
            }

            public class MonsterData
            {
                public Monster? this[string key]
                {
                    get
                    {
                        nameTable.TryGetValue(key, out Monster? value);
                        return value;
                    }
                }

                private Dictionary<string, Monster> nameTable;
                private Dictionary<int, Monster> numberTable;

                public MonsterData()
                {
                    // 1000개 정도의 자료를 가정하고 2배에 가까운 소수 크기를 예약
                    nameTable = new Dictionary<string, Monster>(1999);
                    numberTable = new Dictionary<int, Monster>(1999);

                    AddMonsterToTable("이상해씨", 1);
                    AddMonsterToTable("릴리요", 346);
                    AddMonsterToTable("한카리아스", 445);
                    AddMonsterToTable("킬가르도", 681);
                    AddMonsterToTable("더시마사리", 748);
                    AddMonsterToTable("따라큐", 778);
                    AddMonsterToTable("드래펄트", 887);
                }

                private void AddMonsterToTable(string name, int number)
                {
                    Monster monster = new Monster(name, number);
                    nameTable.Add(name, monster);
                    numberTable.Add(number, monster);
                }
            }
        }

        
    }
}

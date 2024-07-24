namespace HW_30101_Class
{
    internal class Program
    {
        struct Position
        {
            public float x;
            public float y;

            public void Move(float value, Direction direction)
            {
                switch (direction)
                {
                    case Direction.Left:
                        x -= value;
                        break;
                    case Direction.Up:
                        y += value;
                        break;
                    case Direction.Right:
                        x += value;
                        break;
                    case Direction.Down:
                        y -= value;
                        break;
                    default:
                        break;
                }
            }
        }

        enum Direction
        {
            Left,
            Up,
            Right,
            Down,
            END
        }

        class Character
        {
            protected int level = 0;
            protected float hp = 10f;
            protected float movementSpeed = 1f;
            protected float attackStats = 5f;

            private Position position;
            private Direction direction;

            public Character()
            {
                direction = Direction.Down;
            }

            public void MoveForward(float time)
            {
                position.Move(time * movementSpeed, direction);
            }

            public void MoveBackward(float time)
            {
                position.Move(time * -movementSpeed, direction);
            }

            public void TurnLeft()
            {
                direction -= 1;
                if(direction < 0)
                {
                    direction = Direction.Down;
                }
            }

            public void TurnRight()
            {
                direction += 1;
                if(direction == Direction.END)
                {
                    direction = Direction.Left;
                }
            }

            public void Attack(Character target)
            {
                target.TakeDamage(attackStats);
            }

            public void TakeDamage(float damage)
            {
                hp -= damage;
                if(hp <= 0f)
                {
                    Dead();
                }
            }

            public virtual void Dead()
            {
                hp = 0f;
                Console.WriteLine("사망 메세지");
            }
        }

        class Monster : Character
        {
            private string name = "이름 없는 몬스터";
            public Monster(string name) : base()
            {
                this.name = name;
            }

            public override void Dead() 
            {
                Console.Write($"{name} 처치");
                if (hp < 0f)
                {
                    Console.Write($"(오버킬: {-hp})");
                    hp = 0f;
                }
            }
        }

        class PlayerCharacter : Character
        {
            public PlayerCharacter() : base()
            {
                level = 1;
                hp = 20f;
                movementSpeed = 5f;
                attackStats = 8f;
            }
        }

        static void Main(string[] args)
        {
            Character monster = new Monster("슬라임");
            Character player = new PlayerCharacter();

            player.Attack(monster);
            player.Attack(monster);
        }
    }
}

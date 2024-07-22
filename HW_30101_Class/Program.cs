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
            private int level;
            private float hp;
            private float movementSpeed;
            private float attackStats;

            private Position position;
            private Direction direction;

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
                target.Attacked(attackStats);
            }

            public void Attacked(float damage)
            {
                hp -= damage;
                if(hp < 0f)
                {
                    hp = 0f;
                    Console.WriteLine("사망 메세지");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

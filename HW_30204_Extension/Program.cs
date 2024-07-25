namespace HW_30204_Extension
{
    public static class Extension
    {
        // 구현해야 하는 확장 메서드
        // 아이디 문자열에 특정 문자가 포함된 경우 false를 반환한다
        public static bool IsAllowedID(this string id)
        {
            foreach (var c in id)
            {
                // 단일 문자 검사
                switch (c)
                {
                    case '!':
                    case '@':
                    case '#':
                    case '$':
                    case '%':
                    case '^':
                    case '&':
                    case '*':
                        return false;
                }
            }

            // 전부 이상 없을시에만 도달 가능
            return true;
        }
    }


    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string? id = Console.ReadLine();

            if (id is null || id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }
    }
}

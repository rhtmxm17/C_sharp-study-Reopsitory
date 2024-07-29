namespace HW_30303_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("괄호 쌍을 검사할 문자열을 입력 해 주세요.");
            string input = Console.ReadLine() ?? "";

            if(BracketPairCheck(input))
            {
                Console.WriteLine("입력한 문자열은 괄호 쌍이 완성되어 있습니다.");
            }
            else
            {
                Console.WriteLine("입력한 문자열은 괄호 쌍이 완성되어 있지 않습니다.");
            }

        }

        /// <summary>
        /// 문자열을 입력받아 괄호 쌍이 올바르게 짝지어져 있는지 검사합니다.
        /// </summary>
        /// <param name="str">괄호 쌍을 검사할 문자열</param>
        /// <returns>괄호가 올바르게 짝지어져있다면 true</returns>
        public static bool BracketPairCheck(string str)
        {
            Stack<char> brackets = new();
            char pop = '\0';
            
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '[':
                    case '{':
                    case '(':
                        brackets.Push(str[i]);
                        break;
                    case ']':
                    case '}':
                    case ')':
                        if (brackets.TryPop(out pop) == false)
                            return false;
                        else if (pop != GetBracketPair(str[i]))
                            return false;
                        break;
                }
            }
            return true;
        }


        /// <summary>
        /// 괄호에 해당하는 문자를 받아 짝을 이루는 괄호 문자를 반환합니다.<br/>
        /// 매개변수로 받은 문자가 다음 목록에 해당하지 않으면 널 문자를 반환합니다.<br/>
        /// []{}()&lt;&gt;
        /// </summary>
        /// <param name="c">괄호 짝을 찾을 문자</param>
        /// <returns>괄호 짝</returns>
        public static char GetBracketPair(char c)
        {
            switch(c)
            {
                case '[':
                    return ']';
                case ']':
                    return '[';
                case '{':
                    return '}';
                case '}':
                    return '{';
                case '(':
                    return ')';
                case ')':
                    return '(';
                case '<':
                    return '>';
                case '>':
                    return '<';
            }
            return '\0';
        }
    }
}

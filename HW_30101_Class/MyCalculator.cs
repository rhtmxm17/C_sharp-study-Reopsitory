namespace HW_30101_Class
{
    static class MyCalculator
    {
        public static double Add(double x, double y)
        {
            return (x + y); 
        }
        public static double Subtract(double x, double y)
        {
            return (x - y);
        }
        public static double Multiply(double x, double y)
        {
            return (x * y);
        }
        public static double Divide(double x, double y)
        {
            if(y == 0.0)
            {
                Console.WriteLine("오류: 0으로 나눌 수 없습니다");
                return 0.0;
            }
            return (x / y);
        }
        public static double Squared(double x, double y)
        {
            // Math.Pow() https://learn.microsoft.com/ko-kr/dotnet/api/system.math.pow?view=net-8.0
            return Math.Pow(x, y);
        }
    }
}

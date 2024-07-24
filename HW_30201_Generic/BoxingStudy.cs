namespace HW_30201_Generic
{
    public static class BoxingStudy
    {
        public interface IDoubleable
        {
            public void Doubleself();
        }

        public struct Point : IDoubleable
        {
            public int x;
            public int y;

            public void Doubleself()
            {
                x *= 2;
                y *= 2;
            }
        }

        public static void DoDouble(IDoubleable val)
        {
            val.Doubleself();
        }

        public static void DoDoubleRef(ref IDoubleable val)
        {
            val.Doubleself();
        }

        public static void DoDoubleGeneric<T>(ref T val) where T : IDoubleable
        {
            val.Doubleself();
        }

        public static void BoxingTest()
        {
            Point point = new Point() { x = 2, y = 5 };

            Console.WriteLine($"point 초기값: {point.x}, {point.y}"); // 2, 5
            point.Doubleself();
            Console.WriteLine($"point.Doubleself() 이후: {point.x}, {point.y}"); // 4, 10
            DoDouble(point);
            Console.WriteLine($"DoDouble(point) 이후: {point.x}, {point.y}"); // 4, 10

            // 원본의 값이 변하지 않은 것으로 DoDouble() 내부의 val이 가리키는 위치가
            // 원본이 아닌 복사본임을 확인 가능

            // 아래 호출은 불가능했음 (struct 참조를 interface 참조로 변환 불가능)
            // DoDoubleRef(ref point);

            DoDoubleGeneric(ref point);
            Console.WriteLine($"DoDoubleGeneric(ref point) 이후: {point.x}, {point.y}"); // 4, 10
        }
    }
}

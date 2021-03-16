namespace MortgageCalculator
{   //**Class other than Main()**
    //**Non-void and static method**
    public static class MathTools
    {
        public static long ToPower(this decimal val, int pow)
        {
            decimal ret = 1;
            for (int i = 0; i < pow; i++)
                ret *= val;
            return (long)ret;
        }

        public static double ToSub(double x, double y)
        {
            return x - y;
        }
    }
}

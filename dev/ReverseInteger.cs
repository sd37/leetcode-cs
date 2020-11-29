namespace dev
{
    using System;

    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            int num = x;

            bool isNegative = x < 0;

            if (isNegative)
            {
                num = -x;
            }

            var revIntStr = ReverseHelper(num.ToString());
            int revInt;

            try
            {
                revInt = int.Parse(revIntStr);
            }
            catch (OverflowException)
            {
                return 0;
            }

            return isNegative ? -1 * revInt : revInt;
        }

        public static string ReverseHelper(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

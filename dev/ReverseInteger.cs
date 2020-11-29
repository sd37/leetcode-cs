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
            
            var revInt = int.Parse(Reverse(num.ToString()));

            return isNegative ? -1 * revInt : revInt;
        }
        
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

namespace dev
{
    using System;

    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            bool isNegative = x < 0;
            var revIntStr = ReverseHelper(x.ToString(), isNegative);

            try
            {
                return int.Parse(revIntStr);
            }
            catch (OverflowException)
            {
                return 0;
            }
        }

        public static string ReverseHelper(string s, bool isNegative)
        {
            string tmpStr = s;
            if(isNegative)
            {
                // ignore sign
                tmpStr = s[1..];
            }

            char[] charArray = tmpStr.ToCharArray();

            Array.Reverse(charArray);
            var revStr = new string(charArray);

            return isNegative ? "-" + revStr : revStr;
        }
    }
}

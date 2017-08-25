using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return aSmile == bSmile;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool SleepIn = false;
            if (!isVacation && isWeekday)
            {
                return SleepIn;
            }
            else if (!isVacation && isWeekday)
            {
                return SleepIn;
            }
            else
            {
                return true;
            }

        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;

            if (a == b)
            {
                return sum *= 2;
            }
            else
            {
                return sum;
            }

        }

        public int Diff21(int n)
        {
            int diff = n - 21;
            if (n > 21)
            {
                return Math.Abs(diff) * 2;
            }
            else
            {
                return Math.Abs(diff);
            }

        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (!isTalking)
            {
                return false;
            }
            else if (isTalking && (hour < 7 || hour > 20))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Makes10(int a, int b)
        {
            if (a + b == 10 || (a == 10))
            {
                return true;
            }
            else if (b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NearHundred(int n)
        {
            if (Math.Abs(n) >= 90 && Math.Abs(n) <= 110 || (Math.Abs(n) >= 190 && Math.Abs(n) <= 210))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (true && (a < 0) && (b < 0))
            {
                return true;
            }
            else if (a > 0 || (b > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public string NotString(string s)
        {
            if (s.IndexOf("not") != 0)
            {
                s = "not " + s;
            }
            return s;

            throw new NotImplementedException();
        }

        public string MissingChar(string str, int n)
        {
            string t = str.Remove(n, 1);
            return t;

        }

        public string FrontBack(string str)
        {
            throw new NotImplementedException();
        }

        public string Front3(string str)
        {
            throw new NotImplementedException();
        }

        public string BackAround(string str)
        {
            throw new NotImplementedException();
        }

        public bool Multiple3or5(int number)
        {
            return number % 3 == 0 || number % 5 == 0;

        }

        public bool StartHi(string str)
        {
            if (str.IndexOf("hi") == 0)
            {
                return true;
            }
            else if (str.IndexOf("hi") != 0)
            {
                return false;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100 || (temp1 > 100 && temp2 < 0))
            {
                return true;
            }
            else return false;
        }

        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20 || (b >= 10 && b <= 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTeen(int a, int b, int c)
        {
            return (a >= 13 && a <= 19 || (b >= 13 && b <= 19 || c >= 13 && c <= 19));
        }

        public bool SoAlone(int a, int b)
        {
            if (a > 13 && a <= 19 || (b > 13))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RemoveDel(string str)
        {

            throw new NotImplementedException();
        }

        public bool IxStart(string str)
        {
            return (str.IndexOf("ix") == 1);

        }

        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }

        public int Max(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }

        public bool GotE(string str)
        {
            throw new NotImplementedException();
        }

        public string EndUp(string str)
        {
            throw new NotImplementedException();
        }

        public string EveryNth(string str, int n)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            return (cigars >= 40) && (cigars <= 60 || isWeekend);

        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp < 60 || isSummer && temp > 100 || !isSummer && temp > 90)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (speed <= 60 || (isBirthday && speed <= 65))
            {
                return 0;
            }
            else if ((speed >= 60 && speed <= 80) || (isBirthday && speed >= 65 && speed <= 85))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum <= 10 || sum >= 19)
            {
                return sum;
            }
            else
            {
                return 20;
            }
        }

        public string AlarmClock(int day, bool vacation)
        {
            string x = "7:00";
            string y = "10:00";

            if (!vacation & day == 0 || day == 6)
            {
                return y;
            }
            else
            {
                return x;
            }
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6 || a + b == 6 || a - b == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode)
            {
                if (n >= 1 || n <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (n >= 1 && n <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SpecialEleven(int n)
        {

            if (n % 11 == 0 || n % 11 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            else if (n % 3 == 0 || n % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isMorning && isMom)
            {
                return true;
            }
            else if (isMorning || isAsleep)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TwoIsOne(int a, int b, int c)
        {

            if (a + b == c || a + c == b || b + c == a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (!bOk && (a < b && b < c) || (bOk && b > a) || (bOk && (a == b)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (!equalOk && (a < b) && (b < c) || (equalOk))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LastDigit(int a, int b, int c)
        {
            return (a % 10 == b % 10 || (b % 10 == c % 10) || (a % 10 == c % 10));

        }

        public int RollDice(int die1, int die2, bool noDoubles)
        {

            if (noDoubles && die1 == die2)
            {
                return (die1 + 1) + die2;
            }
            else if (die1 == 6 && noDoubles && die1 == die2)
            {
                return die1 = 1;
            }
            else
            {
                return die1 + die2;
            }
        }

    }
}

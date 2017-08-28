using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string x = String.Empty;
            for (int i = 0; i < n; i++)
            {
                x += str;
            }
            return x;
        }

        public string FrontTimes(string str, int n)
        {
            string s = string.Empty;
            if(str.Length < 3)
            {
                return str;
            }
            for (int i = 0; i < n; i++)

                s += str.Substring(0, 3);
            
            return s;
        }

        public int CountXX(string str)
        {
            
            int counter = 0;
            for (int i = 0; i < str.Length -1 ; i++)

                if(str.Substring(i, 2) == "xx")
                {
                    counter++;
                }
            return counter;

        }

        public bool DoubleX(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
                if ((str.Substring(i, 1) == "x") && (str.Substring(i + 1, 1) != "x"))
                    return false;
                else if((str.Substring(i,1) == "x") && str.Substring(i + 1,1) == "x")
                    return true;

            return false;
        }
        
        public string EveryOther(string str)
        {
            string x = String.Empty;
            for (int i = 0; i < str.Length; i += 2)
            {
                x += str[i];
            }
            return x;

        }

        public string StringSplosion(string str)
        {
            string s = String.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                s += str.Substring(0, i);
            }    
            return s + str;
        }

        public int CountLast2(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(0, 2) == str.Substring(str.Length - 3, 2))
                {
                    return 2;
                }

            }
            return 1;             
        }

        public int Count9(int[] numbers)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    counter++;
                }
            }
            return counter;
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                if (numbers.Length >= 3 && numbers[i] == 1 && numbers[i] == 2 && numbers[i] == 3)
                {
                    return true;
                }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            string s = String.Empty;
            for(int i = 0; i < str.Length; i++)
            {
                if((str.Contains("x") && (str.Substring(0,1) != "x") && ((str.Substring(str.Length-1) == "x"))))
                {
                    s += str.Remove('x');
                }

            }
            return s;

        }

        public string AltPairs(string str)
        {
            string s = string.Empty;
            for (int i = 0; i < str.Length - 2; i += 4)
            {
                s += str[i];
            }
            return s;
        }

        public string DoNotYak(string str)
        {
            string s = string.Empty;
            for(int i = 0; i < str.Length; i++)
            {
                if (str.Contains("yak"))
                {
                    
                }
            }
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}

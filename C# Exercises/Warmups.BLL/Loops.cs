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
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[0] == 9 || numbers[1] == 9 || numbers[2] == 9 || numbers[3] == 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i+1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int counter = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                for (int j = 0; j < b.Length-1; j++)
                {
                    if (a.Substring(i, 2) == b.Substring(j, 2))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public string StringX(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if(str.Substring(0,1) == "x" && str.Substring(str.Length - 1) == "x")
                {
                    str = str.Replace("x", "");
                    str = "x" + str + "x";
                }
                if (str.Contains("x") == true && str.Substring(0, 1) != "x" && str.Substring(str.Length-1) != "x")
                {
                    str = str.Replace("x", "");
                }
            }
            return str;
        }

        public string AltPairs(string str)
        {
            string stringA = "";
            string stringB = "";
            string stringC = "";
            for (int i = 0; i < str.Length; i++)
            {
                if(str.Length == 9)
                {
                    stringA = str.Substring(0, 2);
                    stringB = str.Substring(4, 2);
                    stringC = str.Substring(8,1);
                }
                else if(str.Length > 9)
                {
                    stringA = str.Substring(0, 2);
                    stringB = str.Substring(4, 2);
                    stringC = str.Substring(8, 2);
                }
                else
                {
                    stringA = str.Substring(0, 2);
                    stringB = str.Substring(4, 2);
                }

            }

            return stringA + stringB + stringC;
        }
        public string DoNotYak(string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                if(str.Contains("yak")==true)
                {
                    str = str.Remove(str.IndexOf("yak"), 3);
                }
            }
            return str;
        }
        public int Array667(int[] numbers)
        {
            int counter = 0;
            for(int i = 0; i < numbers.Length-1; i++)
            {
                if(numbers[i] == 6 && numbers[i + 1] == 6 || numbers[i + 1] == 7)
                {
                    counter++;
                }
            }
            return counter;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] == numbers[i + 1]) && ((numbers[i + 1] == numbers[i + 2])))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 2; i++)
            {
                if(numbers[i] == 2 && numbers[i + 1] == 7 && numbers[i + 2] == 1)
                {
                    return true;
                }
                else if (numbers[i] == 6)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

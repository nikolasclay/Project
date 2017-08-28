using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return (a + b) + (b + a);
            throw new NotImplementedException();
        }

        public string MakeTags(string tag, string content)
        {
            return ("<" + tag + ">" + content + "</" + tag + ">");
            throw new NotImplementedException();
        }

        public string InsertWord(string container, string word)
        {
            string x = container.Substring(0, 2) + word + container.Substring(container.Length - 2);
            return (x);

        }

        public string MultipleEndings(string str)
        {
            string x = "";
            x = str.Substring(str.Length - 2);
            return x + x + x;
        }

        public string FirstHalf(string str)
        {
            return str.Substring(0, str.Length / 2);

        }

        public string TrimOne(string str)
        {
            return str.Substring(1, str.Length - 2);

        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            else
            {
                return a + b + a;
            }
        }

        public string RotateLeft2(string str)
        {
            string s = str.Substring(2);
            if (str.Length > 2)
            {
                s += str.Substring(0, 2);
                return s;
            }
            else
            {
                return str;
            }
        }

        public string RotateRight2(string str)
        {
            string s = str.Substring(str.Length - 2);
            if (str.Length > 2)
            {
                s += str.Remove(str.Length - 2);
                return s;
            }
            else
            {
                return str;
            }
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            else {
                return str.Substring(str.Length - 1);
            }
        }

        public string MiddleTwo(string str)
        {
            str = str.Substring((str.Length / 2) - 1, 2);
            return str;
        }

        public bool EndsWithLy(string str)
        {
            if (str.Contains("ly") && str.Substring(str.Length - 2, 2) == "ly")
            {
                return true;
            }
            else
            {
                return false;
            }



            throw new NotImplementedException();
        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n == 2)
            {
                return str.Substring(2, 2);
            }
            else
            {
                return str.Substring(0, 2);
            }


            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            if (str.Contains("bad") && str.IndexOf("bad") == 0 || str.IndexOf("bad") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AtFirst(string str)
        {
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            if (a == String.Empty && b == String.Empty)
            {
                return "@@";
            }
            else if (a == String.Empty)
            {
                return "@" + b.Substring(b.Length - 1);
            }
            else if (b == string.Empty)
            {
                return a.Substring(0, 1) + "@";
            }
            else
            {
                return a.Substring(0, 1) + b.Substring(b.Length - 1);
            }

        }

        public string ConCat(string a, string b)
        {
            if (a == String.Empty)
            {
                return b;
            }
            else if(b == string.Empty)
            {
                return a;
            }
            else if(a.Substring(a.Length - 1) == b.Substring(0,1))
            {
                return a + b.Substring(1);
            }
            else
            {
                return a + b;
            }

        }

        public string SwapLast(string str)
        {
            if (str.Length == 1)
            {
                return str;
            }
            else if (str.Length <= 2)
            {
                return str.Substring(str.Length - 1) + str.Substring(0, 1);
            }
            else
            {
                return (str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1) + str.Substring(str.Length - 2, 1));
            }
        }

        public bool FrontAgain(string str)
        {
            if (str.Length == 2)
            {
                return true;
            }
            else if (str.Substring(0, 2) == str.Substring(str.Length - 2, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MinCat(string a, string b)
        {
            if (a == String.Empty || b == String.Empty)
            {
                return String.Empty;
            }
            else if (a.Length > b.Length)
            {
                return a.Substring(a.Length - b.Length) + b;
            }
            else if (b.Length > a.Length)
            {
                return a + b.Substring(b.Length - a.Length);
            }
            else
            {
                return a + b;
            }

        }

        public string TweakFront(string str)
        { 
            if(str == String.Empty)
            {
                return String.Empty;
            }
            else if(str.IndexOf("a") == 0 && str.IndexOf("b") == 1)
            {
                return str;
            }
            else if (str.IndexOf("a") == 0)
            {
                return str.Remove(1, 1);
            }
            else if (str.IndexOf("b") == 1)
            {
                return str.Remove(0, 1);
            }
            else if(str.IndexOf("a") != 0 || str.IndexOf("b") != 1)
            {
                return str.Remove(0,2);
            }
            else
            {
                return str;
            }
        }

        public string StripX(string str)
        {
            if (str == String.Empty)
            {
                return String.Empty;
            }
            else if(str.IndexOf("x") == 0 && str.Length <= 2)
            {
                return string.Empty;
            }
            else if(str.IndexOf("x") == 0 && str.Substring(str.Length -1) == "x")
            {
                str = str.Remove(str.Length - 1);
                str = str.Remove(0,1);
                return str;

            }
            else if(str.IndexOf("x") == 0)
            {
                return str.Remove(0, 1);
            }
            else if (str.Substring(str.Length -1) == "x")
            {
                return str.Remove(str.Length - 1);
            }
            else{
                return str;
            }

        }
    }
}

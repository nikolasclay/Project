using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] == 6)
                {
                    return true;
                }
                else if (numbers[numbers.Length - 1] == 6)
                {
                    return true;
                }

            }
             return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if((numbers.Length >= 1 && (numbers[0]  == numbers[numbers.Length - 1])))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int[] MakePi(int n)
        {

            for(int i = 0; i < n; i++)
            {
                
            }

            throw new NotImplementedException();
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length + b.Length; i++)
            {
                if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
                {
                    return true;
                }
            }
            return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] n = { numbers[1] , numbers[2] , numbers[0] };
            return n;
        }


        public int[] Reverse(int[] numbers)
        {
                int[] n = { numbers[2], numbers[1], numbers [0] };
                return n;
        }

        public int[] HigherWins(int[] numbers)
        {

                if(numbers[0] > numbers[numbers.Length - 1])
                {
                    int[] n = { numbers[0] };
                    return n;
                }
                else if(numbers[numbers.Length - 1] > numbers[0])
                {
                    int[] n = { numbers[numbers.Length - 1] };
                    return n;
                }
            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    return true; 
            }
            return false;
           

        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}

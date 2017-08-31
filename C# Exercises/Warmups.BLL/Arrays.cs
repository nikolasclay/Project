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
            if ((numbers.Length >= 1 && (numbers[0] == numbers[numbers.Length - 1])))
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

            int[] newArray = new int[] { 3, 1, 4, 1, 5, 9, 2, 6 };
            int[] MyArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                MyArray[i] = newArray[i];
            }
            return MyArray;
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
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] n = { numbers[1], numbers[2], numbers[0] };
            return n;
        }


        public int[] Reverse(int[] numbers)
        {

            Array.Reverse(numbers);
            return numbers;
        }


        public int[] HigherWins(int[] numbers)
        {
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[0] > numbers[numbers.Length - 1])
                {
                    newArray[i] = numbers[0];



                }
                else if (numbers[numbers.Length - 1] > numbers[0])
                {
                    newArray[i] = numbers[numbers.Length - 1];
                }

            }
            return newArray;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] MyArray = new int[2];

            MyArray[0] = a[1];
            MyArray[1] = b[1];
            return MyArray;
        }

        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    return true;
            }
            return false;


        }

        public int[] KeepLast(int[] numbers)
        {
            int[] MyArray = new int[numbers.Length + numbers.Length];


            MyArray[MyArray.Length - 1] = numbers[numbers.Length - 1];
            return MyArray;
        }


        public bool Double23(int[] numbers)
        {
            int counter = 0;
            int counter1 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)

                    counter++;

                else if (numbers[i] == 3)

                    counter1++;

            }
            if ((counter == 2) || (counter1 > 1 && counter1 < 3))

                return true;
            else
            {
                return false;
            }
        }

        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                    numbers[i + 1] = 0;

            }
            return numbers;
        }

        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    return true;
                }
                else if (numbers[i + 1] == 1 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;

        }

        public int[] Make2(int[] a, int[] b)
        {
            int[] MyArray = new int[2];

            if (a.Length == 2)
            {
                MyArray[0] = a[0];
                MyArray[1] = a[1];
            }
            else if (a.Length == 0)
            {
                MyArray[0] = b[0];
                MyArray[1] = b[1];
            }
            else if (a.Length == 1)
            {
                MyArray[0] = a[0];
                MyArray[1] = b[0];
            }

                return MyArray;
            
        }
    }
    }


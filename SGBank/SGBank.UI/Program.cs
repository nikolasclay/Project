using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Console.Clear();
                Menu.Start();
            }
        }
    }
}

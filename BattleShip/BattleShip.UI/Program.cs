using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isplayAgain = true;
            while (isplayAgain)
            {
                Setup_Workflow flow = new Setup_Workflow();
                GameState state = flow.Start();


                GameWorkFlow.GoPlay(state);

                Console.WriteLine("Do you want to play again? Press 'y' for Yes or 'q' to Quit.");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    Console.Clear();
                    flow.Start();
                }
                else if(input == "q")
                {
                    Console.ReadKey();
                }
            }
          
        }

    }
}

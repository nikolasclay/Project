using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Setup_Workflow flow = new Setup_Workflow();
            GameState state = flow.Start();
            

            GameWorkFlow.GoPlay(state);
          
        }

    }
}

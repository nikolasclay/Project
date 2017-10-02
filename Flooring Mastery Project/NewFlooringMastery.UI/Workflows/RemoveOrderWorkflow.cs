using NewFlooringMastery.BLL;
using NewFlooringMastery.Models;
using NewFlooringMastery.Models.Requests;
using NewFlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.UI.Workflows
{
    class RemoveOrderWorkflow
    {
        internal void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

        }
        
    }
}


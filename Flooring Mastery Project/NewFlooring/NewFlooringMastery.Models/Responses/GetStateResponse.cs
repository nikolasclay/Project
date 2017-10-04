using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFlooringMastery.Models.Responses
{
    public class GetStateResponse : Response
    {
        public StateTaxInfo TaxData { get; set; }
    }
}

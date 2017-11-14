using CarDealership.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class CarFactory
    {
        public static ICarRepository Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new TestRepository();

                case "EF":
                    return new EFRepository();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}


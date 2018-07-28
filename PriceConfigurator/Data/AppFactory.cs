using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppFactory
    {
        public static IAppRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFRepo();

                case "ADO":
                    return new ADORepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

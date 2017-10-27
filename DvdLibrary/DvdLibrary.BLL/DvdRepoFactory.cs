using DvdLibrary.Data;
using DvdLibrary.Data.ADO;
using DvdLibrary.Data.EF;
using DvdLibrary.Data.Mock;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.BLL
{
    public class DvdRepoFactory
    {
        public static IDvdRepository Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "MockRepo":
                    return new MockDvdRepository();

                case "ADORepo":
                    return new DvdRepositoryADO();
                case "EFRepo":
                    return new DvdRepositoryEF();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

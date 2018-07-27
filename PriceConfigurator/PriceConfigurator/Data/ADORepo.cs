using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceConfigurator.Model;

namespace Data
{
    public class ADORepo : IAppRepo
    {
        IAppRepo _repo = AppFactory.Create();

        public void AddApp(App app)
        {
            throw new NotImplementedException();
        }

        public void DeleteApp(int id)
        {
            throw new NotImplementedException();
        }

        public List<App> GetAll()
        {
            throw new NotImplementedException();
        }

        public App GetAppById(int id)
        {
            throw new NotImplementedException();
        }

        public App GetAppByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateApp(App app)
        {
            throw new NotImplementedException();
        }

        IEnumerable<App> IAppRepo.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

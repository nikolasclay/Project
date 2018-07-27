using PriceConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IAppRepo
    {
        //IEnumerable<App> GetAll();
        IEnumerable<App> GetAll();
        App GetAppById(int id);
        App GetAppByTitle(string title);
        void AddApp(App app);
        void DeleteApp(int id);
        void UpdateApp(App app);
    }
}

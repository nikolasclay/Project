using DvdLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd GetDvdById(int id);
        List<Dvd> GetDvdsByTitle(string title);
        List<Dvd> GetDvdsByReleaseYear(int year);
        List<Dvd> GetDvdsbyDirector(string director);
        List<Dvd> GetDvdsbyRating(string rating);
        void AddDvd(Dvd dvd);
        void EditDvd(Dvd dvd);
        void DeleteDvd(int id);
    }
}

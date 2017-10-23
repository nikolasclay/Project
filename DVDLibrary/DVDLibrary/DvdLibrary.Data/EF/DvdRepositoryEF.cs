using DvdLibrary.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;

namespace DVDLibrary.Data.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDvd(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDvd(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsbyDirector(string director)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsbyRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByReleaseYear(int year)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}

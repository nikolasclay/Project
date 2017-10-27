using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Model;
using System.Data.Entity;
using DvdLibrary.Data;

namespace DvdLibrary.Data.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        DvdLibraryEntities entity = new DvdLibraryEntities();
        public void AddDvd(Dvd dvd)
        {
            if (entity.Dvds.Count() == 0)
            {
                dvd.DvdId = 1;
            }
            else
            {
                var maxID = entity.Dvds.Max(d => d.DvdId);
                dvd.DvdId = maxID + 1;
            }
            entity.Dvds.Add(dvd);
            entity.SaveChanges();
        }

        public void DeleteDvd(int id)
        {
            Dvd d = entity.Dvds.Find(id);
            entity.Dvds.Remove(d);
            entity.SaveChanges();
        }

        public void EditDvd(Dvd dvd)
        {
            entity.Entry(dvd).State = EntityState.Modified;
        }

        public List<Dvd> GetAll()
        {
            return entity.Dvds.ToList();
        }

        public Dvd GetDvdById(int id)
        {
            return entity.Dvds.FirstOrDefault(d => d.DvdId == id);
        }

        public List<Dvd> GetDvdsbyDirector(string director)
        {
            return entity.Dvds.Where(d => d.DirectorName == director).ToList();
        }

        public List<Dvd> GetDvdsbyRating(string rating)
        {
            return entity.Dvds.Where(d => d.RatingType == rating).ToList();
        }

        public List<Dvd> GetDvdsByReleaseYear(int year)
        {
            return entity.Dvds.Where(d => d.ReleaseYear == year).ToList();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            return entity.Dvds.Where(d => d.Title == title).ToList();
        }
    }
}

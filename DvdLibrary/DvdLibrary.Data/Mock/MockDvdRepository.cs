    using DvdLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Mock
{
    public class MockDvdRepository : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            {
                DvdId = 1,
                Title = "True Hollywood Stories",
                ReleaseYear = 2017,
                DirectorName = "Charlie Murphy",
                RatingType = "R",
                Notes = "Game, blouses."
            },
            new Dvd
            {
                DvdId = 2,
                Title = "East West Bowl",
                ReleaseYear = 1999,
                DirectorName = "Hingle McCringleberry",
                RatingType = "R",
                Notes = "A movie so bad, it's good!"
            },

            new Dvd
            {
                DvdId = 3,
                Title = "The Mad Real World",
                ReleaseYear = 2012,
                DirectorName = "Tron",
                RatingType = "R",
                Notes = "Hot hand in the dice game, baby!"
            },
        };
        public void AddDvd(Dvd dvd)
        {
            if (_dvds.Count() == 0)
            {
                dvd.DvdId = 1;
            }
            else
            {
                var maxID = _dvds.Max(d => d.DvdId);
                dvd.DvdId = maxID + 1;
            }
            _dvds.Add(dvd);
        }

        public void DeleteDvd(int id)
        {
            _dvds.RemoveAll(d => d.DvdId == id);
        }

        public void EditDvd(Dvd dvd)
        {
            var editedDvd = _dvds.FirstOrDefault(d => d.DvdId == dvd.DvdId);
            editedDvd.Title = dvd.Title;
            editedDvd.ReleaseYear = dvd.ReleaseYear;
            editedDvd.DirectorName = dvd.DirectorName;
            editedDvd.RatingType = dvd.RatingType;
            editedDvd.Notes = dvd.Notes;

            editedDvd = dvd;

        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetDvdById(int id)
        {
            return _dvds.FirstOrDefault(d => d.DvdId == id);
        }

        public List<Dvd> GetDvdsbyDirector(string director)
        {
            //Need to return all Dvds by the director so list is required
            return _dvds.Where(d => d.DirectorName == director).ToList();
        }

        public List<Dvd> GetDvdsbyRating(string rating)
        {
            //Need to return all Dvds with specified rating so list is required
            return _dvds.Where(d => d.RatingType == rating).ToList();
        }

        public List<Dvd> GetDvdsByReleaseYear(int year)
        {
            return _dvds.Where(d => d.ReleaseYear == year).ToList();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            return _dvds.Where(d => d.Title == title).ToList();
        }
    }
}


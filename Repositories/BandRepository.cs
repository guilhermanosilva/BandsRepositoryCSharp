using System.Collections.Generic;
using bands_repository_csharp.Entities;

namespace bands_repository_csharp.Repositories
{
    public class BandRepository : IBandRepository<Band>
    {
        private List<Band> listBand = new List<Band>();

        public void Delete(int id)
        {
            listBand[id].delete();
        }

        public void InsertBand(Band band)
        {
            listBand.Add(band);
        }

        public List<Band> ListRepository()
        {
            return listBand;
        }

        public int NextId()
        {
            return listBand.Count;
        }

        public Band ReturnBandId(int id)
        {
            return listBand[id];
        }

        public void UpdateBand(int id, Band band)
        {
            listBand[id] = band;
        }
    }
}
using System.Collections.Generic;

namespace bands_repository_csharp.Repositories
{
    public interface IBandRepository<T>
    {
        List<T> ListRepository();
        T ReturnBandId(int id);
        void InsertBand(T band);
        void UpdateBand(int id, T band);
        void Delete(int id, T band);
        int NextId();
    }
}
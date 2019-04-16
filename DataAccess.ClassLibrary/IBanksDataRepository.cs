using System.Collections.Generic;

namespace DataAccess.ClassLibrary
{
    public interface IBanksDataRepository
    {
        List<Bank> GetAllBanks();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public interface IDebitAccountsRepository
    {
        List<DebitAccounts> GetDebitAccounts(string CNP);
    }
}

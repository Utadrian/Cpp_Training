using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccess.ClassLibrary
{
    public interface IClientsDataRepository
    {
        List<Client> GetAllClients(int bankId);
        int GetClientsCount(int bankId);
        Object GetAccountDetails(string CNP, int AccId, int AccType);
        void AddNewClient(string CNP, string Name, DateTime b_date, int id_bank);
        bool PerformFinancialTransaction(string CNPsender, int AccIdSender, int AccIdReciever, AccType AccTypeSender, AccType AccTypeReciever, int SumTransfered);
    }
}

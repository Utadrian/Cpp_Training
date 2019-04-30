using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public class DebitAccountsRepository : IDebitAccountsRepository
    {
        public List<DebitAccounts> GetDebitAccounts (string CNP)
        {
            List<DebitAccounts> debitList = new List<DebitAccounts>();
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"SELECT id_debit AS IdContDebit, currency AS Valuta
                                                         FROM Adi.DEBIT_ACCOUNTS
                                                         WHERE CNP_client = @CNP", sqlConn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNP));

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            debitList.Add(new DebitAccounts { DebitId = (int)reader["IdContDebit"], Valută = (string)reader["Valuta"] });
                        }
                    }
                }
            }
            return debitList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public class CreditAccountsRepository : ICreditAccountsRepository
    {
        public List<CreditAccounts> GetCreditAccounts(string CNP)
        {
            List<CreditAccounts> creditAccountsList = new List<CreditAccounts>();
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"SELECT id_credit AS IdContCredit, currency AS Valuta
                                                         FROM Adi.CREDIT_ACCOUNTS
                                                         WHERE CNP_client = @CNP", sqlConn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNP));

                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            creditAccountsList.Add(new CreditAccounts { CreditId = (int)reader["IdContCredit"], Valută = (string)reader["Valuta"] });
                        }
                    }
                }
            }
            return creditAccountsList;
        }
    }
}

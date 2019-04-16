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
    public class BanksDataRepository : IBanksDataRepository
    {
        public List<Bank> GetAllBanks()
        {
            List<Bank> bankList = new List<Bank>();
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"select 
	                                                                id_bank as Id,
	                                                                name as BankName
                                                                 from 
 	                                                                Adi.Banks", sqlConn))
                {
                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            bankList.Add(new Bank { Id = (int)reader["Id"], Name = (string)reader["BankName"] });
                        }
                    }
                    
                }
            }

            return bankList;
        }
    }
}

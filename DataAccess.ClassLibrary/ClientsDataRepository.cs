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
    public class ClientsDataRepository : IClientsDataRepository
    {
        public List<Client> GetAllClients(int bankId)
        {
            List<Client> clientList = new List<Client>();
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"select 
	                                                                CNP,
	                                                                name as ClientName
                                                                 from 
 	                                                                Adi.Clients
                                                                 where id_bank = @bankId", sqlConn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@bankId", bankId));
                    using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            clientList.Add(new Client { CNP = (string)reader["CNP"], Name = (string)reader["ClientName"] });
                        }
                    }

                }
            }
            return clientList;
        }

        public int GetClientsCount(int bankId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"select COUNT(*)
                                                                 from 
 	                                                                Adi.Clients
                                                                 where id_bank = @bankId", sqlConn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@bankId", bankId));
                    return (int)sqlCommand.ExecuteScalar();
                }

            }
        }

        public void AddNewClient(string Name, string CNP, DateTime b_date, int id_bank)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var sqlCommand = new SqlCommand(@"INSERT INTO [Adi].[CLIENTS]
	                                                                	([CNP]
	                                                                	,[name]
	                                                                	,[b_date]
	                                                                	,[id_bank])
	                                                     VALUES
	                                                     	(@CNP
	                                                     	,@name
	                                                     	,@b_date
	                                                     	,@id_bank)", sqlConn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNP));
                    sqlCommand.Parameters.Add(new SqlParameter("@name", Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@b_date", b_date));
                    sqlCommand.Parameters.Add(new SqlParameter("@id_bank", id_bank));

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch(SqlException e)
                    {
                        throw new CNPTriggerException(e.Message);
                    }
                }
            }
        }
        public Object GetAccountDetails(string CNP, int AccId, int AccType)
        {
            if (AccType == 1)
            {
                CompleteCreditAccounts creditAccount = new CompleteCreditAccounts();
                var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    using (var sqlCommand = new SqlCommand(@"SELECT *
                                                         FROM Adi.CREDIT_ACCOUNTS
                                                         WHERE CNP_client = @CNP AND id_credit = @CreditID", sqlConn))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNP));
                        sqlCommand.Parameters.Add(new SqlParameter("@CreditID", AccId));

                        using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                creditAccount = new CompleteCreditAccounts { CreditId = (int)reader["id_credit"], Valută = reader["currency"].ToString(), SumăCurentă = reader["current_sum"].ToString(), CNPclient = reader["CNP_client"].ToString(), ProcentDobândă = (int)reader["interest_rate"], PerioadăÎnLuni = (int)reader["time_period"], SumăIniţială = reader["initial_sum"].ToString() };
                            }
                        }
                    }
                }
                return creditAccount;
            }
            else if (AccType == 2)
            {
                CompleteDebitAccounts debitAccount = new CompleteDebitAccounts();
                var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    using (var sqlCommand = new SqlCommand(@"SELECT *
                                                         FROM Adi.DEBIT_ACCOUNTS
                                                         WHERE CNP_client = @CNP AND id_debit = @CreditID", sqlConn))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNP));
                        sqlCommand.Parameters.Add(new SqlParameter("@CreditID", AccId));

                        using (var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                debitAccount = new CompleteDebitAccounts { DebitId = (int)reader["id_debit"], Valută = (string)reader["currency"], SumăCurentă = reader["current_sum"].ToString(), CNPclient = (string)reader["CNP_client"] };
                            }
                        }
                    }
                }
                return debitAccount;

            }
            return null;
        }

        public bool PerformFinancialTransaction(string CNPsender, int AccIdSender, int AccIdReciever, AccType AccTypeSender, AccType AccTypeReciever, int SumTransfered)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataAccess.ClassLibrary.Properties.Settings.ConnectionString1"].ConnectionString;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlTransaction sqlTransaction;
                sqlTransaction = sqlConn.BeginTransaction(IsolationLevel.ReadUncommitted);
                try
                {
                    switch (AccTypeSender)
                    {
                        case AccType.Credit:
                            using (var sqlCommand = new SqlCommand(@"UPDATE Adi.CREDIT_ACCOUNTS
                                                             SET current_sum = current_sum - @TransferedSum
                                                             WHERE CNP_client = @CNP AND id_credit = @CreditID", sqlConn, sqlTransaction))
                            {
                                sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNPsender));
                                sqlCommand.Parameters.Add(new SqlParameter("@CreditID", AccIdSender));
                                sqlCommand.Parameters.Add(new SqlParameter("@TransferedSum", SumTransfered));

                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case AccType.Debit:
                            using (var sqlCommand = new SqlCommand(@"UPDATE Adi.DEBIT_ACCOUNTS
                                                             SET current_sum = current_sum - @TransferedSum
                                                             WHERE CNP_client = @CNP AND id_debit = @DebitID", sqlConn, sqlTransaction))
                            {
                                sqlCommand.Parameters.Add(new SqlParameter("@CNP", CNPsender));
                                sqlCommand.Parameters.Add(new SqlParameter("@DebitID", AccIdSender));
                                sqlCommand.Parameters.Add(new SqlParameter("@TransferedSum", SumTransfered));

                                sqlCommand.ExecuteNonQuery();
                            }
                            break;
                    }
                    switch (AccTypeReciever)
                    {
                        case AccType.Credit:
                            CompleteCreditAccounts creditAccount = new CompleteCreditAccounts();
                            using (var sqlCommand = new SqlCommand(@"UPDATE Adi.CREDIT_ACCOUNTS
                                                             SET current_sum = current_sum + @TransferedSum
                                                             WHERE id_credit = @CreditID", sqlConn, sqlTransaction))
                            {
                                sqlCommand.Parameters.Add(new SqlParameter("@CreditID", AccIdReciever));
                                sqlCommand.Parameters.Add(new SqlParameter("@TransferedSum", SumTransfered));

                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case AccType.Debit:
                            CompleteDebitAccounts debitAccount = new CompleteDebitAccounts();
                            using (var sqlCommand = new SqlCommand(@"UPDATE Adi.DEBIT_ACCOUNTS
                                                             SET current_sum = current_sum + @TransferedSum
                                                             WHERE id_debit = @DebitID", sqlConn, sqlTransaction))
                            {
                                sqlCommand.Parameters.Add(new SqlParameter("@DebitID", AccIdReciever));
                                sqlCommand.Parameters.Add(new SqlParameter("@TransferedSum", SumTransfered));

                                sqlCommand.ExecuteNonQuery();
                            }
                            break;
                    }
                    sqlTransaction.Commit();
                }
                catch
                {
                    sqlTransaction.Rollback();
                    return false;
                }
            }
            return true;
        }
    }
}

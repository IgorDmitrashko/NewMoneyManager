using MoneyManager.BL.Classes;
using MoneyManager.BL.Interface;
using MoneyManager.BL.Properties;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoneyManager.BL
{
    public class DBManager : IDBManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Ожидание>")]
        public void SetDBHistories(IDBHistory history) {
            using(IDbConnection con = new SqlConnection(Settings.Default.DBMoneyManage))
            {
                IDbCommand command = new SqlCommand($"INSERT INTO MyDBMoneyManager(Username, SumMoney) VALUES('{history.UserName}', '{history.Money}');");

                command.Connection = con;
                con.Open();
                IDataReader reader = command.ExecuteReader();
            }
        }

        public List<DBHistory> GetDBHistories() {
            using(IDbConnection con = new SqlConnection(Settings.Default.DBMoneyManage))
            {
                IDbCommand command = new SqlCommand("SELECT * FROM MyDBMoneyManager");

                command.Connection = con;
                con.Open();

                IDataReader reader = command.ExecuteReader();
                List<DBHistory> HistoryDB = new List<DBHistory>();

                DBHistory history = new DBHistory();

                while(reader.Read())
                {
                    history.Id = reader.GetInt32(0);
                    history.UserName = reader.GetString(1);
                    history.Money = reader.GetDecimal(2);
                    history.Date = reader.GetDateTime(3);

                    HistoryDB.Add(history);
                }

                return HistoryDB;
            }
        }
    }
}
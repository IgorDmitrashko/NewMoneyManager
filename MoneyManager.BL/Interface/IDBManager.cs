using MoneyManager.BL.Classes;
using System.Collections.Generic;

namespace MoneyManager.BL.Interface
{
    public interface IDBManager
    {
        List<DBHistory> GetDBHistories();

        void SetDBHistories(IDBHistory history);
    }
}
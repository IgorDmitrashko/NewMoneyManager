using MoneyManager.BL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BL.Interface
{
    public interface IDBManager
    {
        List<DBHistory> GetDBHistories();
        void SetDBHistories(IDBHistory history);
    }
}

using System;

namespace MoneyManager.BL.Interface
{
    public interface IDBHistory
    {
        int Id { get; set; }
        string UserName { get; set; }
        decimal Money { get; set; }
        DateTime Date { get; set; }
    }
}
using MoneyManager.BL.Interface;
using System;

namespace MoneyManager.BL.Classes
{
    public struct DBHistory : IDBHistory
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Money { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }

        public override string ToString() {
            return $"Id - {Id}\t UserName - {UserName}\t Money - {Money}\t Data - {Date}\t Status {Status}";
        }
    }

    public enum Status
    {
        Profit,
        Lesion
    }
}
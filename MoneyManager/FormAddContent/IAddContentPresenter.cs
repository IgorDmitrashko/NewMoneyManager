using MoneyManager.BL.Interface;
using System;
using System.Windows.Controls;

namespace MoneyManager.Control.Interface
{
    public interface IAddContentPresenter
    {
        DataGrid DataGridDBHistory { get; set; }
        IDBHistory History { get; }

        event EventHandler WievDataGridDBHistory;

        event EventHandler SetDataBaseContent;
    }
}
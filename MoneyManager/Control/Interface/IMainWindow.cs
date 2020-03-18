using MoneyManager.BL.Classes;
using System;
using System.Collections.Generic;

namespace MoneyManager
{
    public interface IMainWindow
    {
        event EventHandler AddContent;

        event EventHandler GetWeather;

        event EventHandler CurrentMoney;

        void DgDbHistiry(List<DBHistory> value);

        object LWeather { get; set; }

        void LCurrentMoney(string value);
    }
}
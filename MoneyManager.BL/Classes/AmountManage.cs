using System.Collections.Generic;

namespace MoneyManager.BL.Classes
{
    public class AmountManage
    {
        private decimal currentMoney;

        public string CurrentMoney(List<DBHistory> dBs) {
            foreach(var item in dBs)
            {
                currentMoney += item.Money;
            }

            return currentMoney.ToString();
        }
    }
}
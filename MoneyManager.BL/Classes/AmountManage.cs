using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BL.Classes
{
   public class AmountManage
    {
        private decimal currentMoney;

        public string CurrentMoney(List<DBHistory> dBs) {
            foreach (var item in dBs)
            {
                currentMoney += item.Money;
            }

            return currentMoney.ToString();
        }

    }
}

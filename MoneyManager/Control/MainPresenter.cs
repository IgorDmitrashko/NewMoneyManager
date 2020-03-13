using System;
using MoneyManager.BL.Classes;
using MoneyManager.BL.Interface;
using MoneyManager.Control.Interface;
using WeatherInKyiv;

namespace MoneyManager
{
    class MainPresenter:EventArgs
    {
        private readonly IMainWindow _view;
        private readonly IDBManager _manager;
        private readonly IDBHistory _history;
        private readonly IAddContentPresenter _addContent;

        public MainPresenter(IMainWindow view, IDBManager manager, IDBHistory history, AddContent addContent) {

            _view = view;
            _manager = manager;
            _history = history;
            _addContent = addContent;

            _view.GetWeather += GetWeather;
            _view.CurrentMoney += CurrentMoney;

            _addContent.WievDataGridDBHistory += WiewContent;
            _addContent.SetDataBaseContent += View_AddDataBaseContent;
        }

        #region MainForm
        private void CurrentMoney(object sender, EventArgs e) {
            AmountManage am = new AmountManage();
            _view.LCurrentMoney(am.CurrentMoney(_manager.GetDBHistories()));
        }

        private void View_AddSpending(object sender, EventArgs e) {
            _manager.SetDBHistories(_history);
            _view.DgDbHistiry(_manager.GetDBHistories());
        }

        private void View_AddDataBaseContent(object sender, EventArgs e) {
            IDBHistory history = (IDBHistory)sender;
            _manager.SetDBHistories(history);
            _view.DgDbHistiry(_manager.GetDBHistories());
            _addContent.DataGridDBHistory.ItemsSource = _manager.GetDBHistories();
        }

        private void GetWeather(object sender, EventArgs e) {
            ControlWeather cw = new ControlWeather();
            _view.LWeather = cw.GetWeather();
        }
        #endregion
        #region AddContentForm

        private void WiewContent(object sender, EventArgs e) {
            _addContent.DataGridDBHistory.ItemsSource = _manager.GetDBHistories();
        }
        #endregion
    }
}

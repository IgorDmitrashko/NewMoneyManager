using MoneyManager.BL;
using MoneyManager.BL.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MoneyManager
{

    public partial class MainWindow : Window, IMainWindow
    {

        MainPresenter mainPresenter;
        AddContent addContent2;
        public MainWindow() {

            InitializeComponent();
            addContent2 = new AddContent(dgDataBase);

            buttonAddProfit.Click += buttonAddProfit_Click;
            buttonAddSpending.Click += ButtonAddSpending_Click;
            weather.Loaded += Window_Loaded;
            lcurentMoney.Loaded += Window_Loaded;

            mainPresenter = new MainPresenter(this, new DBManager(), new DBHistory(), addContent2);

        }


        #region I record the visual component
        public void DgDbHistiry(List<DBHistory> value) { dgDataBase.ItemsSource = value; }

        public object LWeather { get { return labelWeatherTemperature.Content; } set { labelWeatherTemperature.Content = value; } }
        public void LCurrentMoney(string value) { lcurentMoney.Content = value; }
        #endregion

        #region Event forwarding
        private void buttonAddProfit_Click(object sender, RoutedEventArgs e) {
            addContent2.Show();
        }


        private void ButtonAddSpending_Click(object sender, RoutedEventArgs e) {
            AddContent?.Invoke(this, EventArgs.Empty);
            CurrentMoney?.Invoke(this, EventArgs.Empty);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            GetWeather?.Invoke(this, EventArgs.Empty);
            CurrentMoney?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler AddProfit;
        public event EventHandler AddContent;
        public event EventHandler GetWeather;
        public event EventHandler CurrentMoney;


        #endregion

    }
}

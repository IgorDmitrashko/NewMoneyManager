using MoneyManager.BL;
using MoneyManager.BL.Classes;
using MoneyManager.BL.Interface;
using MoneyManager.Control.Interface;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MoneyManager
{
    /// <summary>
    /// Логика взаимодействия для AddContent.xaml
    /// </summary>
    public partial class AddContent : Window, IAddContentPresenter
    {
        private ModelContent _modelContent;

        public DataGrid DataGridDBHistory { get; set; }
        public IDBHistory History { get; }

        public AddContent(DataGrid dt) {
            InitializeComponent();
            DataGridDBHistory = dt;
            _modelContent = new ModelContent();
            this.DataContext = _modelContent;
            buttonAddContent.Click += ButtonAddContent_Click;
            buttonCancel.Click += ButtonCancel_Click;
        }

        private void ButtonAddContent_Click(object sender, RoutedEventArgs e) {

            SetDataBaseContent?.Invoke(GetContent(tBUserName, tBMoney), EventArgs.Empty);
            buttonAddContent.IsEnabled = false;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            this.Hide();
            WievDataGridDBHistory?.Invoke(this, EventArgs.Empty);
        }

        private void tBUserName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {

            buttonAddContent.IsEnabled = true;

        }

        private void tBMoney_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {


            buttonAddContent.IsEnabled = true;
        }

        private IDBHistory GetContent(TextBox name, TextBox money) {
            decimal sum;
            DBHistory history = new DBHistory();
            history.UserName = name.Text;
            bool result = decimal.TryParse(money.Text, out sum);
            if(!result)
            {
                MessageBox.Show("Неверные данные");
                history.Money = 0;
                return history;
            }
            else
            {
                history.Money = sum;
                return history;
            }
        }


        public event EventHandler WievDataGridDBHistory;
        public event EventHandler SetDataBaseContent;
    }
}

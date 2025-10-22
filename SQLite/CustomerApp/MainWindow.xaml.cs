using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private List<Customer> _customers = new List<Customer>();

    public MainWindow()
    {
        InitializeComponent();
        ReadDatabase();

        CustomerListView.ItemsSource = _customers;
    }

    public void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customers = connection.Table<Customer>().ToList();
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            //Picture = PictureImage.Resources.Values as Byte[]
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }

        ReadDatabase();
        CustomerListView.ItemsSource = _customers;
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selectedPerson = CustomerListView.SelectedItem as Customer;
        if (selectedPerson is null) return;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            var person = new Customer() {
                Id = selectedPerson.Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
            };

            connection.Update(person);
            ReadDatabase();
            CustomerListView.ItemsSource = _customers;
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item == null) {
            InfoTextBox.Text = "行を選択してください";
            return;
        }

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);
        }

        ReadDatabase();
        CustomerListView.ItemsSource = _customers;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text));

        CustomerListView.ItemsSource = filterList;
    }

    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item == null) return;
        NameTextBox.Text = item.Name;
        PhoneTextBox.Text = item.Phone;
        AddressTextBox.Text = item.Address;
    }

    private void PictureButton_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog ofd = new OpenFileDialog();
        var of = ofd.ShowDialog();
        if(of ?? false) {
            //PictureImage.Resources.Add();
        }
    }
}
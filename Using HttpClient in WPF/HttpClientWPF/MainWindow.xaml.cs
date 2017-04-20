using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using EmployeeWebAPI.Models;

namespace HttpClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BindEmployeeList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62848/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/employee").Result;
            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                grdEmployee.ItemsSource = employees;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62848/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            var employee = new Employee();

            employee.Id = int.Parse(txtId.Text);
            employee.Name = txtName.Text;
            employee.Address = txtAddress.Text;
            employee.Designation = txtDesignation.Text;

            var response = client.PostAsJsonAsync("api/employee", employee).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Employee Added");
                txtId.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtDesignation.Text = "";
                BindEmployeeList();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62848/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var id = txtId.Text.Trim();

            var url = "api/employee/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsAsync<Employee>().Result;
                MessageBox.Show("Employee Found : " + employees.Name + " " + employees.Address + " " + employees.Designation);
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }













        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12789/");

            var id = txtId.Text.Trim();

            var url = "api/employee/" + id;

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("User Deleted");
                BindEmployeeList();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }



    }

 
}

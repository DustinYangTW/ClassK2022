using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53860/api/Values");
            HttpResponseMessage resp = client.GetAsync("http://localhost:53860/api/Values").Result;
            IEnumerable<Rootobject> data = null;

            if (resp.IsSuccessStatusCode)
            {
                data = resp.Content.ReadAsAsync<IEnumerable<Rootobject>>().Result;

                foreach (var item in data)
                {
                    listBox1.Items.Add("客戶名稱:" + item.CompanyName + ", 聯絡人:" + item.ContactName + ", 職稱:" + item.ContactTitle);
                }

            }


        }
        public class Rootobject
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public object Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public object[] Orders { get; set; }
            public object[] Orders1 { get; set; }
        }
    }
}

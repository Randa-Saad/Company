using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company.DesktopConsumer
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            //it happened while loading page
            InitializeComponent();
            FillEmployeesIntoGridView();
            FillEmployeesIntoComboBox();
        }

        private void FillEmployeesIntoComboBox()
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:59383/api/employees").Result;
            if (result.IsSuccessStatusCode)
            {
                var msg = result.Content.ReadAsAsync<List<Emp>>().Result;
                comboBox1.DataSource = msg;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
        }

        private void FillEmployeesIntoGridView()
        {
            HttpClient client = new HttpClient(); 
            var result = client.GetAsync("http://localhost:59383/api/employees").Result; 
            if(result.IsSuccessStatusCode)
            {
                var msg = result.Content.ReadAsAsync<List<Emp>>().Result;
                dataGridView1.DataSource = msg;
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var EnteredEmp = new Emp { Id = int.Parse(textId.Text),Name=textName.Text, Age = int.Parse(textAge.Text),Salary = Decimal.Parse(textSalary.Text), DeptId = int.Parse(textDeptId.Text)};

            client.BaseAddress = new Uri("http://localhost:59383/");
            var result = client.PostAsJsonAsync("api/employees", EnteredEmp).Result;
            if(result.IsSuccessStatusCode)
            {
                FillEmployeesIntoGridView();
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var EnteredEmp = new Emp { Id = int.Parse(textId.Text), Name = textName.Text, Age = int.Parse(textAge.Text), Salary = Decimal.Parse(textSalary.Text), DeptId = int.Parse(textDeptId.Text) };

            var result=client.PostAsJsonAsync($"http://localhost:59383/api/employees/{textId.Text}", EnteredEmp).Result;
            if (result.IsSuccessStatusCode)
            {
                FillEmployeesIntoGridView();
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.Purple;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
          var result= client.GetAsync($"http://localhost:59383/api/employees/{comboBox1.SelectedIndex}").Result;
            if(result.IsSuccessStatusCode)
            {
                var emp = result.Content.ReadAsAsync<Emp>().Result;
                textId.Text = emp.Id.ToString();
                textName.Text = emp.Name;
                textAge.Text = emp.Age.ToString();
                textSalary.Text = emp.Salary.ToString();
                textDeptId.Text = emp.DeptId.ToString();
               
            }
            else
            {
                MessageBox.Show(result.ReasonPhrase + " " + result.StatusCode);
            }
   
        }
    }
}

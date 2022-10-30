using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Model;
using WindowsFormsApp3.Service;

namespace WindowsFormsApp3.Presentation
{
    public partial class PersonForm : Form
    {
        public PersonForm()
        {
            InitializeComponent();
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            var result = PersonAppService.GetAllPersonList();

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.PersonList;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var person = new Person
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Address = textBox3.Text,
                City = textBox4.Text,

            };
           var result =  PersonAppService.CreatePerson(person);
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Refresh();
                MessageBox.Show("New Person data has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

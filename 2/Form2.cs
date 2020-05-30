using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form2 : Form
    {
        public Model1 db { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show(" Нужно ввести все требуемые данные!");
                return;
            }
            int id;
            bool b = int.TryParse(textBox1.Text, out id);
            if (b == false)
            {
                MessageBox.Show(" Неверный формат ID - " +textBox1.Text);
                return;
            }
            Students st = new Students();
            st.ID = id;
            st.Name = textBox2.Text;
            db.Students.Add(st);
            try
            {
                db.SaveChanges(); 
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}

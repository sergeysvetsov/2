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
    public partial class Form3 : Form
    {
        public Model1 db { get; set; }
        public Students st { get; set; }

        public Form3()

        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = st.ID.ToString();
            textBox2.Text = st.Name;
            textBox3.Text = st.Gruppa;
            textBox4.Text = st.Vozrast.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st.Name = textBox2.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

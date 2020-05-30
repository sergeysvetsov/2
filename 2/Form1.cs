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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Students st = (Students)studentsBindingSource.Current;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить - " + st.ID.ToString() + " " + st.Name.ToString() + " " , "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dr == DialogResult.Yes)
            {
                db.Students.Remove(st);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                studentsBindingSource.DataSource = db.Students.ToList();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            studentsBindingSource.DataSource = db.Students.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            frm.db = db;

            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                studentsBindingSource.DataSource = db.Students.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            Students st = (Students)studentsBindingSource.Current;
            frm.db = db;
            frm.st = st;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                studentsBindingSource.DataSource = db.Students.ToList();

            }
        }
    }
}




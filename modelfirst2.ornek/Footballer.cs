using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace modelfirst2.ornek
{
    public partial class Footballer : Form
    {
        public Footballer()
        {
            InitializeComponent();
        }
        FutbolContainer container = new FutbolContainer();
        private void Form1_Load(object sender, EventArgs e)
        {
            var uniqueData = container.FutbolcuSet.Select(x => x.AntrenorId).Distinct().ToList();
            comboBox1.DataSource = uniqueData;
            //combobox1.datasource = container.urunlers.tolist
            //comboBox1.ValueMember = "AntrenorId";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Futbolcu futbolcu = new Futbolcu();
            futbolcu.Fname = textBox1.Text;
            futbolcu.Fulke = textBox2.Text;
            futbolcu.Fmaas =decimal.Parse(textBox3.Text);
            futbolcu.Fkulup = textBox4.Text;
            futbolcu.AntrenorId = int.Parse(comboBox1.Text);
            container.FutbolcuSet.Add(futbolcu);
            container.SaveChanges();
            dataGridView1.DataSource = container.FutbolcuSet.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.FutbolcuSet.Where
           (a => a.Fname.ToLower().Contains(textBox1.Text)
           || a.Fname.ToUpper().Contains(textBox1.Text)).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.FutbolcuSet.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["FutbolcuId"].Value.ToString();
            textBox1.Text = column.Cells["Fname"].Value.ToString();
            textBox2.Text = column.Cells["Fulke"].Value.ToString();
            textBox3.Text = column.Cells["Fmaas"].Value.ToString();
            textBox4.Text = column.Cells["Fkulup"].Value.ToString();
            comboBox1.Text = column.Cells["AntrenorId"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = container.FutbolcuSet.Where(a => a.FutbolcuId == id).FirstOrDefault();

            container.FutbolcuSet.Remove(deleteEmp);
            container.SaveChanges();
            dataGridView1.DataSource = container.FutbolcuSet.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = container.FutbolcuSet.Where(x => x.FutbolcuId == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.

            update.Fname = textBox1.Text;
            update.Fulke = textBox2.Text;
            update.Fmaas = decimal.Parse(textBox3.Text);
            update.Fkulup = textBox4.Text;
            update.AntrenorId =int.Parse(comboBox1.Text);


            container.SaveChanges();
            dataGridView1.DataSource = container.FutbolcuSet.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TD go = new TD();
            go.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Baskanlar go = new Baskanlar();
            go.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var query2 = container.FutbolcuSet.Where(futbolcu => futbolcu.Fulke == textBox5.Text).
                OrderBy(ftbl => ftbl.Fname);
            dataGridView1.DataSource = query2.ToList();
        }
    }
}

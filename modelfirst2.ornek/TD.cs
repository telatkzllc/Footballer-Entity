using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modelfirst2.ornek
{
    public partial class TD : Form
    {
        public TD()
        {
            InitializeComponent();
        }
        FutbolContainer container = new FutbolContainer();
        private void TD_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource=container.AntrenorSet.ToList();
            comboBox1.ValueMember = "Id";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Antrenor antrenor = new Antrenor();
            antrenor.Amaas =decimal.Parse(textBox1.Text);
            antrenor.Aname = textBox2.Text;
            antrenor.Aulke = textBox3.Text;
            antrenor.Akulup=textBox4.Text;
            antrenor.BaskanId =int.Parse(comboBox1.Text);
            container.AntrenorSet.Add(antrenor);
            container.SaveChanges();
            dataGridView1.DataSource = container.AntrenorSet.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.AntrenorSet.ToList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.AntrenorSet.Where
           (a => a.Aname.ToLower().Contains(textBox1.Text)
           || a.Aname.ToUpper().Contains(textBox1.Text)).ToList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = container.AntrenorSet.Where(a => a.Id == id).FirstOrDefault();

            container.AntrenorSet.Remove(deleteEmp);
            container.SaveChanges();
            dataGridView1.DataSource = container.AntrenorSet.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = container.AntrenorSet.Where(x => x.Id == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.

            update.Amaas = decimal.Parse(textBox1.Text);
            update.Aname = textBox2.Text;
            update.Aulke = (textBox3.Text);
            update.Akulup = textBox4.Text;
            update.BaskanId = int.Parse(comboBox1.Text);


            container.SaveChanges();
            dataGridView1.DataSource = container.AntrenorSet.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["Id"].Value.ToString();
            textBox1.Text = column.Cells["Amaas"].Value.ToString();
            textBox2.Text = column.Cells["Aname"].Value.ToString();
            textBox3.Text = column.Cells["Aulke"].Value.ToString();
            textBox4.Text = column.Cells["Akulup"].Value.ToString();
            comboBox1.Text = column.Cells["BaskanId"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Footballer go = new Footballer();
            go.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Baskanlar go = new Baskanlar();
            go.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var query = from x in container.AntrenorSet
                        orderby x.Amaas descending
                        select new { x.Aname,x.Aulke,x.Akulup,x.Amaas };
            dataGridView1.DataSource = query.ToList();
        }
    }
}

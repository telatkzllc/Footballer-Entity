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
    public partial class Baskanlar : Form
    {
        FutbolContainer container=new FutbolContainer();
        public Baskanlar()
        {
            InitializeComponent();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            TD go= new TD();
            go.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Footballer go= new Footballer();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baskan bskn = new Baskan();
            bskn.Bname = textBox1.Text;
            bskn.Bage=int.Parse(textBox2.Text);
            bskn.Bunvan = textBox3.Text;
            bskn.SKId = int.Parse(textBox4.Text);
            container.BaskanSet.Add(bskn);
            container.SaveChanges();
            dataGridView1.DataSource = container.BaskanSet.ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = container.BaskanSet.Where(x => x.Id == ID).FirstOrDefault();

            update.Bname = textBox1.Text;
            update.Bage =int.Parse(textBox2.Text);
            update.Bunvan = (textBox3.Text);
            update.SKId = int.Parse(textBox4.Text);

            container.SaveChanges();
            dataGridView1.DataSource = container.BaskanSet.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = container.BaskanSet.Where(a => a.Id == id).FirstOrDefault();

            container.BaskanSet.Remove(deleteEmp);
            container.SaveChanges();
            dataGridView1.DataSource = container.BaskanSet.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.BaskanSet.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["Id"].Value.ToString();
            textBox1.Text = column.Cells["Bname"].Value.ToString();
            textBox2.Text = column.Cells["Bage"].Value.ToString();
            textBox3.Text = column.Cells["Bunvar"].Value.ToString();
            textBox4.Text = column.Cells["SKId"].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = container.BaskanSet.Where
          (a => a.Bname.ToLower().Contains(textBox1.Text)
          || a.Bname.ToUpper().Contains(textBox1.Text)).ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var query = from yas in container.BaskanSet
                        orderby yas.Bage descending
                        select yas;
            dataGridView1.DataSource = query.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Yas ortalaması al
            var query = from urun in container.BaskanSet
                        group urun by urun.Bunvan into gruplandir
                        select new
                        {
                            BaskanUnvan = gruplandir.Key,
                            ortalama = gruplandir.Average(x => x.Bage)
                        };
            dataGridView1.DataSource = query.ToList();

        }
    }
}

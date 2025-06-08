using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = String.Format("{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}", "Šifra", "Ime", "Prezime", "Adresa", "Grad", "Telefon");
            comboBox1.DisplayMember = "Grad";
            comboBox1.ValueMember = "GradID";
            comboBox1.DataSource = Pecaros.UcitajSve();
            PrikaziPodatke();
        }

        private void PrikaziPodatke()
        {
            listBox1.DisplayMember = "Prikaz";
            listBox1.ValueMember = "PecarosID";
            listBox1.DataSource = Pecaros.UcitajSve();
            listBox1.SelectedIndex = 0;
            Pecaros p = new Pecaros(Convert.ToInt32(listBox1.SelectedValue.ToString()));
            textBox1.Text = p.PecarosID.ToString();
            textBox2.Text = p.Ime;
            textBox3.Text = p.Prezime;
            textBox4.Text = p.Adresa;
            comboBox1.Text = p.Grad;
            textBox5.Text = p.Telefon;
            listBox1.SelectedValue = p.PecarosID;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pecaros p = new Pecaros(Convert.ToInt32(listBox1.SelectedValue.ToString()));
            textBox1.Text = p.PecarosID.ToString();
            textBox2.Text = p.Ime;
            textBox3.Text = p.Prezime;
            textBox4.Text = p.Adresa;
            comboBox1.Text = p.Grad;
            textBox5.Text = p.Telefon;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                comboBox1.Text = String.Empty;
                textBox5.Text = String.Empty;
            }
            else
            {
                Pecaros p = new Pecaros(Convert.ToInt32(textBox1.Text));
                textBox2.Text = p.Ime;
                textBox3.Text = p.Prezime;
                textBox4.Text = p.Adresa;
                comboBox1.Text = p.Grad;
                textBox5.Text = p.Telefon;
                listBox1.SelectedValue = Convert.ToInt32(textBox1.Text);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pecaros p = new Pecaros(Convert.ToInt32(textBox1.Text));
            p.PecarosID = Convert.ToInt32(textBox1.Text);
            p.Ime = textBox2.Text;
            p.Prezime = textBox3.Text;
            p.Adresa = textBox4.Text;
            p.GradID = Convert.ToInt32(comboBox1.SelectedValue);
            p.Telefon = textBox5.Text;
            if (p.Izmeni())
                MessageBox.Show("Uspešna izmena");
            PrikaziPodatke();
        }

        Form2 f2 = new Form2();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            f2.ShowDialog();
        }

        Form3 f3 = new Form3();
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            f3.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

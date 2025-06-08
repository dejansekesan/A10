using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace A10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Value = DateTimePicker.MaximumDateTime;
            comboBox1.DisplayMember = "PrikazPecarosa";
            comboBox1.ValueMember = "PecarosID";
            comboBox1.DataSource = Pecaros.UcitajSve();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                int sifra = (int)comboBox1.SelectedValue;
                DateTime godinaOd = dateTimePicker1.Value;
                DateTime godinaDo = dateTimePicker2.Value;
                DataTable dt = Pecaros.Statistika(sifra, godinaOd, godinaDo);
                dataGridView1.DataSource = dt;
                chart1.DataSource = dt;
                chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
                chart1.Series["Series1"].XValueMember = "Vrsta";
                chart1.Series["Series1"].YValueMembers = "Broj";
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
                MessageBox.Show("Odaberite pecaroša!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
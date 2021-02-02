using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFunction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)comboBox1.SelectedItem;
            switch (selected)
            {
                case "Spline":
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "Line":
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break;
                default:
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar == ',' || e.KeyChar == '-')
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void x(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(this.textBox1.Text);
            double b = Convert.ToDouble(this.textBox2.Text);
            double h = Convert.ToDouble(this.textBox3.Text);

            double x = a;
            this.chart1.Series[0].Points.Clear();
            this.Column2.DataGridView.Rows.Clear();
            while (x <= b)
            {
                double y = getFunction(x);

                this.chart1.Series[0].Points.AddXY(x, y);
                this.Column2.DataGridView.Rows.Add(x, y);
                x += h;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private double getFunction(double x)
        {
            return Math.Sqrt(Math.Pow(x, 3));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Column2.DataGridView.Rows.Clear();
            this.chart1.Series[0].Points.Clear();
        }

        private void openFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    try
                    {
                        string CSVFilePathName = openFileDialog1.FileName;
                        string[] Lines = File.ReadAllLines(CSVFilePathName);
                        string[] Fields;
                        Fields = Lines[0].Split(new char[] { ';' });
                        int Cols = Fields.GetLength(0);
                        DataTable dt = new DataTable();
                        //1st row must be column names; force lower case to ensure matching later on.
                        for (int i = 0; i < Cols; i++)
                            dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                        DataRow Row;
                        for (int i = 1; i < Lines.GetLength(0); i++)
                        {
                            Fields = Lines[i].Split(new char[] { ',' });
                            Row = dt.NewRow();
                            for (int f = 0; f < Cols; f++)
                                Row[f] = Fields[f];
                            dt.Rows.Add(Row);
                        }
                        this.dataGridView5.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error is " + ex.ToString());
                        throw;
                    }
                }
            }


        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)

        {

        }
    }
}

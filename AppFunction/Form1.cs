using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
            string selected = (string) comboBox1.SelectedItem;
            switch(selected)
            {
                case "Spline":
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "Line":
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break;
                case "Point":
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
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
            while(x<=b)
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


        private void clickSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "scv files (*.scv)|*.scv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            int row = dataGridView5.Rows.Count;
            int cell = dataGridView5.Rows[1].Cells.Count;
            Console.WriteLine(row);
            Console.WriteLine(cell);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.Unicode))
                {

                    for (int i = 0; i < row; i++)
                    {
                        string str = "";
                        for (int j = 0; j < cell; j++)
                        {
                            if (dataGridView5.Rows[i].Cells[j].Value != null)
                            {
                                str += dataGridView5.Rows[i].Cells[j].Value.ToString() + ";";
                            }
                            
                        }
                        sw.WriteLine(str);
                    }
                    sw.Close();
                    sw.Dispose();
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Column2.DataGridView.Rows.Clear();
            this.chart1.Series[0].Points.Clear();
        }
    }
}

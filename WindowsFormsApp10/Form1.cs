using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Rows.Add();

            }
            for (int i = 0; (i<=(dataGridView1.Rows.Count-1)); i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString();
            }
            
        }
        Random rand = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = rand.Next(16000,30000);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int max = 0;
            for (int i = 0; i < 3; i++)
            {
                max = int.Parse(dataGridView1[i, 0].Value.ToString());
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (int.Parse(dataGridView1[i, j].Value.ToString()) >= max)
                    {
                        max = int.Parse(dataGridView1[i, j].Value.ToString());
                    }  
                }
            }
            MessageBox.Show($"Максимальная зарплата:{max}");
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            int[] arr = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int sum = 0;
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    int x = 0;
                    sum += int.TryParse(cell.Value == null ? "0" : cell.Value.ToString(), out x) ? x : 0;
                }
                arr[i] = sum;
            }

            MessageBox.Show($"Наибольшую сумму за квартал получил работник №{(arr.ToList().IndexOf(arr.Max()))+1} его сумма зп за квартал: {arr.Max()}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] arr = new int[3];
                for (int f = 0; f < 3; f++) {
                int sum = (int)dataGridView1.Rows[0].Cells[f].Value;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
   
                        sum += (int)dataGridView1.Rows[i].Cells[f].Value;

                }
                arr[f] = sum;
            }
            
            MessageBox.Show($"Максимальная  общая зарплата сотрудников была в месяце №{(arr.ToList().IndexOf(arr.Max()))+1} сумма зп:{arr.Max()}");
        }
    }
}

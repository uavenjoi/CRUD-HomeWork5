using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(id);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"E:\DEC.txt", FileMode.Create);//try{}...
            StreamWriter streamWriter = new StreamWriter(fs);//using (StreamWriter streamWriter = new StreamWriter(fs))

            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "#");
                    }

                    streamWriter.Write("$");
            }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fStream = new FileStream(@"E:\DEC.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fStream);

            string[] str;
            int numberOfRows = 2;
           
                string[] str1 = streamReader.ReadToEnd().Split('$');
                numberOfRows = str1.Count();

            dataGridView1.RowCount = numberOfRows;
                for (int i = 0; i < numberOfRows - 1; i++)
                {
                    str = str1[i].Split('#');
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = str[j];
                    }
                }
            fStream.Close();
            streamReader.Close();
        }
            
        }

      
    }





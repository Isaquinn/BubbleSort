using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BubbleSort2._0
{

    public partial class sort : Form
    {
        Graphics g;
        public static List<string> numeros = new List<string>();
        int valor;
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan time;
        public static int contador;
        Random random = new Random();
        public sort()
        {
            InitializeComponent();


        }
        private void button3_Click(object sender, EventArgs e)
        {
         

            stopwatch.Start();
            listBox1.Items.Clear();

            BubbleSort(numeros);

            listBox1.Items.AddRange(numeros.ToArray());
          

            chart1.Series["numbersgrafics"].Points.DataBindY(numeros);
            chart1.Refresh();



            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Tempo.Text = time.ToString();
        }
        private void DrawSamples()
        {
            g = listBox2.CreateGraphics();
            g.Clear(Color.White);

            for (int i = 0; i < numeros.Count; i++)
            {
                int x = listBox2.Width / numeros.Count * i;
                //BubbleSort(numeros);
                Pen pen = new Pen(Color.Black);
                g.DrawLine(pen, new Point(x, listBox2.Height),
                new Point(x, (int)(listBox2.Height - Convert.ToInt32((string)numeros[i]))));
            }

        }


        private void Inicializar_Click(object sender, EventArgs e)
        {

            chart1.Series["numbersgrafics"].Points.Clear();
            listBox1.Items.Clear();
            numeros.Clear();

            contador = numeros.Count;





            if (textBox1.Text == "" && textBox2.Text == "")
            {
                return;
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                return;
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                return;
            }
            else {


                while (contador < 20)
                {
                    valor = random.Next(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
                    NoRepeat(valor.ToString());

                    contador++;

                    chart1.Series["numbersgrafics"].Points.DataBindY(numeros);

                }


                listBox1.Items.AddRange(numeros.ToArray());



                label5.Text = numeros.Count.ToString();
            }
            DrawSamples();


        }
        static void BubbleSort(List<string> numeros)
        {
            for (int i = 0; i < numeros.Count; i++)
            {
                for (int k = i + 1; k < numeros.Count; k++)
                {
                    if (int.Parse(numeros[i]) > int.Parse(numeros[k]))
                    {
                        int temp = (int.Parse(numeros[i]));
                        numeros[i] = numeros[k];
                        numeros[k] = temp.ToString();
                    }
                }
            }
        }

        static void NoRepeat(string item)
        {

            if (!numeros.Contains(item))
            {

                numeros.Add(item);
            }
            else
            {
                contador--;
            }
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            numeros.Clear();
            contador = numeros.Count;
            while (contador < 2000)
            {

                valor = random.Next(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox1.Text));
                contador++;
                NoRepeat(valor.ToString());
                chart1.Series["numbersgrafics"].Points.DataBindY(numeros);
            }

            listBox1.Items.AddRange(numeros.ToArray());
            label5.Text = numeros.Count.ToString();
            DrawSamples();
        }

        private void Zerar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            numeros.Clear();
            label5.Text = "";
        }


    }
}

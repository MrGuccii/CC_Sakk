using System;
using System.Drawing;
using System.Windows.Forms;
using Sakk.Babuk;

namespace Sakk
{

    public partial class Sakk : Form
    {
        public Tabla sakkTabla = new Tabla(8);        

        public Sakk()
        { 
            InitializeComponent();
            panel1.Width = sakkTabla.tabla.GetLength(0) * 70;
            panel1.Height = sakkTabla.tabla.GetLength(1) * 70;
            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(1); h++)
                {
                    sakkTabla.tabla[i, h].gomb.Click += GombNyomas;
                    panel1.Controls.Add(sakkTabla.tabla[i, h].gomb);
                }
            }
        }

        private void GombNyomas(object sender, EventArgs args)
        {
            Button gomb = (Button)sender;
            Point helyzet = gomb.Location;
            Mezo mezo = sakkTabla.tabla[helyzet.X / 70, helyzet.Y / 70];
            sakkTabla.GombNyomas(mezo);
            panelModositas();
        }
        
        private void panelModositas()
        {
            //panel1.Controls.Clear();

            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(1); h++)
                {
					if (sakkTabla.tabla[i, h].changed)
					{
                        if (sakkTabla.tabla[i, h].lepesek && !sakkTabla.tabla[i, h].foglalt)
                        {
                            sakkTabla.tabla[i, h].gomb.BackColor = Color.Gray;
                        }
                        else if (sakkTabla.tabla[i, h].babuFeher)
                        {
                            sakkTabla.tabla[i, h].gomb.BackColor = Color.White;
                        }
                        else if (sakkTabla.tabla[i, h].babuFekete)
                        {
                            sakkTabla.tabla[i, h].gomb.BackColor = Color.Black;
                            sakkTabla.tabla[i, h].gomb.ForeColor = Color.White;
                        }
                        else if (!sakkTabla.tabla[i, h].lepesek)
                        {
                            sakkTabla.tabla[i, h].gomb.BackColor = default(Color);
                        }
                        sakkTabla.tabla[i, h].gomb.Location = new Point(i * 70, h * 70);
                        sakkTabla.tabla[i, h].gomb.Text = sakkTabla.tabla[i, h].babuNeve;
                        sakkTabla.tabla[i, h].gomb.Height = 70;
                        sakkTabla.tabla[i, h].gomb.Width = 70;
                        sakkTabla.tabla[i, h].gomb.Click -= GombNyomas;
                        sakkTabla.tabla[i, h].gomb.Click += GombNyomas;
                        if (sakkTabla.jatekVege)
                        {
                            sakkTabla.tabla[i, h].gomb.Enabled = false;
                        }
                        tableLayoutPanel1.Controls.Add(sakkTabla.tabla[i, h].gomb, i, h);
                        panel1.Controls.Add(sakkTabla.tabla[i, h].gomb);
                        sakkTabla.tabla[i, h].clearChanged();
                    }
                }
            }
            if (sakkTabla.kovetkezoSzin == BabuSzine.FEHER)
            {
                label1.Text = "Fehér játékos következik";
            }
            else
            {
                label1.Text = "Fekete játékos következik";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sakkTabla = new Tabla(8);            
            panel1.Controls.Clear();
            sakkTabla.jatekInditasa();
            panelModositas();
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Canje_Millas
{
    public partial class ingresarDniCanjeMillas : Form
    {
        public ingresarDniCanjeMillas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Funcionalidades.Funcionalidades().Show();
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validaciones.Validaciones.validarMaskedTextBox(maskedTextBox1, "Complete con su DNI"))
            {

                int dni = int.Parse(maskedTextBox1.Text);
                if (ConexionALaBase.Conexion.consultarBase("Select id from MM.clientes where DNI=" + dni).HasRows)
                {
                    new canjeMillas(dni).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El DNI ingresado es incorrecto");
                }
            }
        }

        private void ingresarDniCanjeMillas_Load(object sender, EventArgs e)
        {

        }
    }
}

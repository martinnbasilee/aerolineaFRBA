﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Validaciones;

namespace AerolineaFrba.Login
{
    public partial class RecuperarContraseña1 : Form
    {
        public RecuperarContraseña1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validaciones.Validaciones.validarTextBox(textBox1, "Ingrese un username"))
            {
                String usernameIngresado = textBox1.Text;
                try {Validaciones.Validaciones.validarUsername(usernameIngresado); }
                catch (Exception)
                {
                    MessageBox.Show("No existe el username");
                    new RecuperarContraseña1().Show();
                    this.Close();
                    return;
                }
                new RecuperarContraseña2(usernameIngresado).Show();
                this.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }
    }
}

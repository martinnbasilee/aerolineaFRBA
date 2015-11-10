﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class NuevaRuta : Form
    {
        public NuevaRuta()
        {
            InitializeComponent();
            System.Data.SqlClient.SqlDataReader reader = ConexionALaBase.Conexion.consultarBase("Select descripcion from MM.ciudades");
            ConexionALaBase.CargadorDeEstructuras.cargarComboBox(comboBox1, reader);
            reader.Dispose();
            reader = ConexionALaBase.Conexion.consultarBase("Select descripcion from MM.ciudades");
            ConexionALaBase.CargadorDeEstructuras.cargarComboBox(comboBox2, reader);
            reader.Dispose();
            reader = ConexionALaBase.Conexion.consultarBase("Select descripcion from MM.Tipos_Servicio");
            ConexionALaBase.CargadorDeEstructuras.cargarComboBox(comboBox3, reader);
            reader.Dispose();                               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Abm_Ruta.ABM_RUTA().Show();
            this.Close();
            return;
        }

        private bool estaCompleto(){
            if (Validaciones.Validaciones.validarComboBox(comboBox2,"Completar ciudad de destino")){
                if (Validaciones.Validaciones.validarComboBox(comboBox1,"Completar ciudad de Origen")){
                    if (Validaciones.Validaciones.validarComboBox(comboBox3,"Completar el tipo de servicio")){
                        if (Validaciones.Validaciones.validarMaskedTextBox(maskedTextBox1,"Completar precio base")){
                            if (Validaciones.Validaciones.validarMaskedTextBox(maskedTextBox2,"Completar precio base de encomienda")){
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e) //BOTON CONFIRMAR
        {
            //Falta implementar la insercion en la base
            if (this.estaCompleto())
            {
                String ciudadDestino;
                String ciudadOrigen;
                String servicio;
                String precioBase;
                String precioBaseEncomienda;

                MessageBox.Show("Falta implementar la insercion en la base");
                MessageBox.Show("Operacion exitosa");
                new ABM_RUTA().Show();
                this.Close();
            }

            
           
        }
    }
}

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
    public partial class SeleccionarRuta : Form
    {
        Ruta rutaElegida = new Ruta();
        int idRutaElegida;
        int intencion;
        public SeleccionarRuta(int opcionElegida) //opcion 1=modificar opcion 2=borrar
        {
            intencion = opcionElegida;
            InitializeComponent();
            ConexionALaBase.CargadorDeEstructuras.cargarDataGrid(dataGridView1, "select * from MM.Vista_rutas_aereas");
        }

        private void modificarRuta_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Boton volver
        {
            new ABM_RUTA().Show();
            this.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
                
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                rutaElegida.cargate(row);
                idRutaElegida = int.Parse(row.Cells["Codigo"].Value.ToString());
                
            }
            else
            {
                MessageBox.Show("seleccione una fila");
                new SeleccionarRuta(intencion).Show();
                this.Close();
                return;
            }
              
            
            if (intencion == 1)
            {//vino a modificar
                new ModificarRuta(rutaElegida,idRutaElegida).Show();
                this.Close();
                return;
            }
            else
            { //vino a borrar
                
                ConexionALaBase.Conexion.ejecutarNonQuery("exec mm.eliminarRuta "+ idRutaElegida);
                MessageBox.Show("La ruta fue borrada");
                new ABM_RUTA().Show();
                this.Close();
            }
        }
    }
}

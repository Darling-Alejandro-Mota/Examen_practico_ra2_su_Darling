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

namespace Examen_practico_ra2_su_Darling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void HabilitarCampos()
        {
            txt_Matricula.Enabled = true;
            txt_Nombre.Enabled = true;
            txt_Direccion.Enabled = true;
            txt_Telefono.Enabled = true;
            txt_Email.Enabled = true;
            txt_maestro.Enabled = true;
            Gbo_seccion.SelectedItem = -1;
            Gbo_Area.Enabled = true;
            Gbo_Curso.Enabled = true;
            Gbo_genero.Enabled = true;

        }

        private void DeshabilitarCampos()
        {
            txt_Matricula.Enabled = false;
            txt_Nombre.Enabled = false;
            txt_Direccion.Enabled = false;
            txt_Telefono.Enabled = false;
            txt_Email.Enabled = false;
            txt_maestro.Enabled = false;
            Gbo_seccion.SelectedItem = -1;
            Gbo_Area.Enabled = false;
            Gbo_Curso.Enabled = false;
            Gbo_genero.Enabled = false;
        }



        private void LimpiarCampos()
        {
            txt_Matricula.Clear();
            txt_Nombre.Clear();
            txt_Direccion.Clear();
            txt_Telefono.Clear();
            txt_Email.Clear();
            Gbo_seccion.SelectedItem = -1;
            txt_maestro.Clear();
            Gbo_Area.SelectedIndex = -1;
            Gbo_Curso.SelectedIndex = -1;
            Gbo_genero.SelectedIndex = -1;
        }


        private void GuardarRegistro()
        {
            string registro = $"{txt_Nombre.Text},{Gbo_seccion.SelectedItem},{txt_Matricula.Text},{txt_Direccion.Text},{txt_Telefono.Text},{txt_Email.Text},{txt_maestro.Text},{Gbo_genero.SelectedItem},{Gbo_Curso.SelectedItem},{Gbo_Area.SelectedItem},";
            dgv_Griv.Rows.Add(registro.Split(','));
            GuardarArchivo(registro);
        }

        private void GuardarArchivo(string registro)
        {
            string filePath = "registros.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(registro);
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btn_Eliminar.Enabled = false;
            HabilitarCampos();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
            LimpiarCampos();
            DeshabilitarCampos();
            btn_Guardar.Enabled = false;
            btn_Nuevo.Enabled = true;
            btn_Eliminar.Enabled = true;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Eliminar registro seleccionado del DataGridView
                if (dgv_Griv.SelectedRows.Count > 0)
                {
                    dgv_Griv.Rows.RemoveAt(dgv_Griv.SelectedRows[0].Index);
                }
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_Matricula.Clear();
            txt_Nombre.Clear();
            txt_Direccion.Clear();
            txt_Telefono.Clear();
            txt_Email.Clear();
            Gbo_seccion.SelectedItem = -1;
            txt_maestro.Clear();
            Gbo_Area.SelectedIndex = -1;
            Gbo_Curso.SelectedIndex = -1;
            Gbo_genero.SelectedIndex = -1;
        }
    }
}

using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseno
{
    public partial class frm_perfiles_mantenimiento : Form
    {
        logica logic;

        public frm_perfiles_mantenimiento(string idUsuario)
        {
            InitializeComponent();
            btn_modif.Enabled = false;
            btn_actualizar.Enabled = false;
            btn_cancel.Enabled = false;
            logic = new logica(idUsuario);
        }

        public frm_perfiles_mantenimiento()
        {
        }

        void limpiar()
        {
            tbx_buscarperfil.Text = "";
            txtcodigo.Text = "";
            txtdesc.Text = "";
            txtnombre.Text = "";
            rbhabilitado.Checked = false;
            rbinhabilitado.Checked = false;
            txtcodigo.Focus();
        }


        private void Btn_bsucarperfil_Click(object sender, EventArgs e)
        {
            string perfil = tbx_buscarperfil.Text;
            bool modificar = false;
            try
            {
                DataTable dtModulos = logic.ConsultaLogicaPerfil(perfil);

                foreach (DataRow row in dtModulos.Rows)
                {
                    if (row[0] != null)
                        modificar = true;

                    txtcodigo.Text = (row[0].ToString());
                    txtnombre.Text = (row[1].ToString());
                    txtdesc.Text = (row[2].ToString());
                    if (row[3].ToString() == "1")
                    {
                        rbhabilitado.Checked = true;
                        rbinhabilitado.Checked = false;

                    }
                    if (row[3].ToString() == "0")
                    {
                        rbinhabilitado.Checked = true;
                        rbhabilitado.Checked = false;

                    }
                }

                if (modificar == true)
                {
                    btn_modif.Enabled = true;
                    btn_ingresar.Enabled = false;
                    txtcodigo.Enabled = false;
                    txtnombre.Enabled = false;
                    txtdesc.Enabled = false;
                    rbhabilitado.Enabled = false;
                    rbinhabilitado.Enabled = false;
                }
                else
                {
                    btn_modif.Enabled = false;
                    MessageBox.Show("No se encontró el perfil buscado");
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = true;
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Falta Nombre de Perfil");
            }
            else if (txtdesc.Text == "")
            {
                MessageBox.Show("Falta Descripcion del Perfil");
            }

            else
            {
                string estado = "";
                if (rbhabilitado.Checked)
                {
                    estado = "1";
                }

                if (rbinhabilitado.Checked)
                {
                    estado = "0";
                }
                else
                {
                    estado = "1";
                }

                logic.ingresarperfiles(txtcodigo.Text.ToString(), txtnombre.Text.ToString(), txtdesc.Text.ToString(), estado.ToString());
                MessageBox.Show("Perfil Ingresado Correctamente");
                limpiar();
            }
        }

        private void Btn_modif_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = false;
            btn_cancel.Enabled = true;
            btn_actualizar.Enabled = true;
            btn_modif.Enabled = false;
            txtnombre.Enabled = true;
            txtdesc.Enabled = true;
            rbhabilitado.Enabled = true;
            rbinhabilitado.Enabled = true;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            limpiar();
            btn_modif.Enabled = false;
            btn_actualizar.Enabled = false;
            btn_cancel.Enabled = false;
            btn_ingresar.Enabled = true;
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Falta Nombre de Perfil");
            }
            else if (txtdesc.Text == "")
            {
                MessageBox.Show("Falta Descripcion del Perfil");
            }

            else
            {
                string estado = "";
                if (rbhabilitado.Checked)
                {
                    estado = "1";
                }

                if (rbinhabilitado.Checked)
                {
                    estado = "0";
                }
                else
                {
                    estado = "1";
                }

                logic.Actualizarperfil(txtcodigo.Text.ToString(), txtnombre.Text.ToString(), txtdesc.Text.ToString(), estado.ToString());
                MessageBox.Show("Perfil Actualizado Correctamente");
                btn_modif.Enabled = false;
                btn_actualizar.Enabled = false;
                btn_cancel.Enabled = false;
                btn_ingresar.Enabled = true;
                txtcodigo.Enabled=true;
                limpiar();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_perfiles_mantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}

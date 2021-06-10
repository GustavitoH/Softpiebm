using Entidades;
using Logica;
using System;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmEditUsuarios : Form
    {
        public FrmEditUsuarios()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool validarDatos()
        {
            if (txtOcupac.Text.Equals("") || txtNombr.Text.Equals("") || txtCorreo.Text.Equals("") || txtContra.Text.Equals("") || txtConfirmarContr.Text.Equals(""))
            {
                MessageBox.Show("Por favor, llene los campos indicados");
                return false;
            }
            else
            {
                if (txtContra.Text.Equals(txtConfirmarContr.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Las contraseñas deben coincidir");
                    return false;
                }
            }
        }
        public Usuario us = new Usuario();
        private Usuario crearUsuario()
        {
            us.ID_Usuario = us.ID_Usuario;
            us.Email = txtCorreo.Text;
            us.Contras = txtContra.Text;
            us.Ocupacion = txtOcupac.Text;
            us.User = txtNombr.Text;

            return us;

        }
        UsuarioLN uln = new UsuarioLN();
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            bool val = true;
            if (validarDatos() == true)
            {
                for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
                {
                    if (txtCorreo.Text.Equals(uln.MostrarUsuarioFitro("")[i].Email))
                    {
                        MessageBox.Show("El correo ingresado ya se encuentra registrado");
                        val = false;
                    }
                }
                if (val == true)
                {
                    Usuario us = crearUsuario();
                    if (uln.CreateUsuario(us))
                    {
                        MessageBox.Show("Usuario generado con exito");
                    }
                    this.Close();
                }
            }
        }
    }
}

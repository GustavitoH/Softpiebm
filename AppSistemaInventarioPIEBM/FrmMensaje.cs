using Entidades;
using Logica;
using System;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmMensaje : Form
    {
        public FrmMensaje()
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

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void FrmMensaje_Load(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
            cargarCombo();

        }
        UsuarioLN uln = new UsuarioLN();
        private void cargarCombo()
        {
            foreach (var item in uln.MostrarUsuarioFitro(""))
            {
                cbRemit.AddItem(item.User);
            }

        }
        private bool validarDatos()
        {
            if (txtMsm.Text.Equals("") || cbRemit.selectedIndex == -1)
            {
                MessageBox.Show("Por favor, llene todos los campos indicados");
                return false;
            }
            else
            {
                return true;
            }
        }
        public Mensaje ms = new Mensaje();
        MensajeLN mln = new MensajeLN();
        private Mensaje crearMensaje()
        {
            ms.ID_Mensaje = ms.ID_Mensaje;
            ms.Estado = "No leído";
            ms.Fecha = datePicker.Value;
            ms.Mensajes = txtMsm.Text;
            ms.Remitente = cbRemit.selectedValue;

            return ms;
        }
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true)
            {
                Mensaje m = crearMensaje();
                if (mln.CreateMensaje(m))
                {
                    MessageBox.Show("Mensaje enviado con exito");
                }
                this.Close();
            }
        }
    }
}

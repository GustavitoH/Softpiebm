using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string correoUsuario;
        public string usuario;
        public string cargo;
        private void btnPaciente_Click(object sender, EventArgs e)
        {
            btnDash.BackColor = Color.Transparent;
            btnPaciente.BackColor = Color.FromArgb(237, 237, 237);
            FrmInventario fcm = new FrmInventario();
            fcm.correoUsuario = correoUsuario;
            addPanel(fcm);
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            btnPaciente.BackColor = Color.Transparent;
            btnDash.BackColor = Color.FromArgb(237, 237, 237);
            FrmDashBoard fcm = new FrmDashBoard();
            addPanel(fcm);
        }
        private void addPanel(Form frm)
        {

            if (this.PanelPrincipal.Controls.Count > 0)
            {
                this.PanelPrincipal.Controls.RemoveAt(0);
            }
            panel1.Visible = false;
            frm.TopLevel = false;
            this.PanelPrincipal.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (bunifuSeparator1.Location.ToString().Equals("{X=12,Y=65}"))
            {
                bunifuSeparator1.Location = new Point(12, 44);
                linkLabel1.Visible = false;
            }
            else
            {
                bunifuSeparator1.Location = new Point(12, 65);
                linkLabel1.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBox3.Visible = false;
            pictureBox5.Visible = true;
        }

        int posY = 0;
        int posX = 0;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmMessage fm = new FrmMessage();
            fm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmLogin fl = new FrmLogin();
            fl.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cargo.Equals("Administrador  ") || cargo.Equals("Administradora  "))
            {
                btnDash.Enabled = true;
            }
            else
            {
                btnDash.Enabled = false;
            }
            lbUser.Text = usuario;
            lbCargo.Text = cargo;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



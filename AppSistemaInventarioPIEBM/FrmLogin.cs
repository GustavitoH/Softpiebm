using Logica;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ejemplo@gmail.com";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ejemplo@gmail.com")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "************")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DimGray;
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "************";
                textBox2.ForeColor = Color.DimGray;
            }

        }
        UsuarioLN uln = new UsuarioLN();
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("ejemplo@gmail.com"))
            {
                errorProvider1.SetError(textBox1, "Ingrese su email");
                Advertencia.Visible = true;
            }
            if (textBox2.Text.Equals("************"))
            {
                errorProvider1.SetError(textBox2, "Ingrese su contraseña");
                Advertencia.Visible = true;
            }
            else
            {
                errorProvider1.Dispose();
                bool encontrado = false;
                for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
                {
                    if (uln.MostrarUsuarioFitro("")[i].Email.Equals(textBox1.Text))
                    {
                        encontrado = true;
                    }
                    if (uln.MostrarUsuarioFitro("")[i].Email.Equals(textBox1.Text) && uln.MostrarUsuarioFitro("")[i].Contras != (textBox2.Text))
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }

                    if (uln.MostrarUsuarioFitro("")[i].Email.Equals(textBox1.Text) && uln.MostrarUsuarioFitro("")[i].Contras.Equals(textBox2.Text))
                    {
                        Form1 fm = new Form1();
                        this.Hide();
                        char[] limit = { ' ' };
                        string[] nombs = uln.MostrarUsuarioFitro("")[i].User.Split(limit);
                        fm.usuario = nombs[0] + " " + nombs[1];
                        fm.cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion + "  ";
                        fm.correoUsuario = textBox1.Text;
                        fm.ShowDialog();
                    }
                }
                if (encontrado == false)
                {
                    MessageBox.Show("Usuario no registrado");
                }
            }

        }
        public string mes()
        {
            string mes = "";
            if (DateTime.Now.Month == 1)
            {
                mes = "Enero";
            }
            if (DateTime.Now.Month == 2)
            {
                mes = "Febrero";
            }
            if (DateTime.Now.Month == 3)
            {
                mes = "Marzo";
            }
            if (DateTime.Now.Month == 4)
            {
                mes = "Abril";
            }
            if (DateTime.Now.Month == 5)
            {
                mes = "Mayo";
            }
            if (DateTime.Now.Month == 6)
            {
                mes = "Junio";
            }
            if (DateTime.Now.Month == 7)
            {
                mes = "Julio";
            }
            if (DateTime.Now.Month == 8)
            {
                mes = "Agosto";
            }
            if (DateTime.Now.Month == 9)
            {
                mes = "Septiembre";
            }
            if (DateTime.Now.Month == 10)
            {
                mes = "Octubre";
            }
            if (DateTime.Now.Month == 11)
            {
                mes = "Noviembre";
            }
            if (DateTime.Now.Month == 12)
            {
                mes = "Diciembre";
            }
            return mes;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lbDia.Text = DateTime.Now.Day.ToString();
            lbMes.Text = mes();
        }
    }
}


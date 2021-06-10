using Logica;
using System;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.Day.ToString() + " de " + mes() + ", " + DateTime.Now.Year.ToString();
        }
        UsuarioLN uln = new UsuarioLN();
        ProductoLN pln = new ProductoLN();
        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            cargarDatos();
            lbTot.Text = totalArti();
            bunifuCustomDataGrid1.Columns[0].Width = 75;
            bunifuCustomDataGrid1.Columns[1].Width = 200;
            bunifuCustomDataGrid1.Columns[2].Width = 80;

            bunifuCustomDataGrid2.Columns[0].Width = 75;
            bunifuCustomDataGrid2.Columns[1].Width = 83;
            bunifuCustomDataGrid2.Columns[2].Width = 200;
            bunifuCustomDataGrid2.Columns[3].Width = 275;
            bunifuCustomDataGrid2.Columns[4].Width = 95;
            progresos();
        }
        MensajeLN mln = new MensajeLN();
        private string totalArti()
        {
            int tot = 0;
            for (int i = 0; i < pln.MostrarProductoFitro("").Count; i++)
            {
                tot += pln.MostrarProductoFitro("")[i].Cantidad;
            }
            return tot.ToString(); ;
        }

        private void cargarDatos()
        {
            bunifuCustomDataGrid1.DataSource = uln.MostrarVistaUsuarioFitro("");
            bunifuCustomDataGrid2.DataSource = mln.MostrarMensajeFitro("");
        }
        private void progresos()
        {
            int numerosTot = 0;
            int excelente, bueno, malo, contExc = 0, contBuen = 0, contMalo = 0;

            for (int i = 0; i < pln.MostrarProductoFitro("").Count; i++)
            {
                numerosTot += pln.MostrarProductoFitro("")[i].Cantidad;
                if (pln.MostrarProductoFitro("")[i].Estado.Equals("Excelente"))
                {
                    contExc += pln.MostrarProductoFitro("")[i].Cantidad;
                }
                if (pln.MostrarProductoFitro("")[i].Estado.Equals("Bueno"))
                {
                    contBuen += pln.MostrarProductoFitro("")[i].Cantidad;
                }
                if (pln.MostrarProductoFitro("")[i].Estado.Equals("Malo"))
                {
                    contMalo += pln.MostrarProductoFitro("")[i].Cantidad;
                }
            }
            excelente = ((contExc * 100) / numerosTot);
            bueno = ((contBuen * 100) / numerosTot);
            malo = ((contMalo * 100) / numerosTot);
            circleExcelente.Value = excelente;
            circleBuen.Value = bueno;
            circleMalo.Value = malo;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmEditUsuarios eu = new FrmEditUsuarios();
            eu.ShowDialog();
            cargarDatos();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmMensaje fm = new FrmMensaje();
            fm.ShowDialog();
            cargarDatos();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.CurrentRow.Selected == false)
            {
                MessageBox.Show("Seleccione el usuario que desea eliminar.");
            }
            else
            {
                try
                {
                    var res = MessageBox.Show("¿Esta seguro de eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
                        {
                            if (uln.MostrarUsuarioFitro("").Count > 1)
                            {
                                if ((int)bunifuCustomDataGrid1.CurrentRow.Cells[0].Value == uln.MostrarUsuarioFitro("")[i].ID_Usuario)
                                {
                                    if (uln.DeleteUsuario(uln.MostrarUsuarioFitro("")[i]))
                                    {
                                        MessageBox.Show("Usuario Eliminado con exito");
                                        cargarDatos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Elimación cancelada...");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Si elimina este usuario, no existirán cuentas disponibles", "SoftPiebm");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void bunifuCustomDataGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            if (bunifuCustomDataGrid2.CurrentRow == null)
            {
                MessageBox.Show("Por el momento no se han enviado mensajes", "Mensaje");
            }

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bunifuCustomDataGrid1.CurrentRow == null)
            {
                MessageBox.Show("Por el momento no se han ingresado usuarios", "Mensaje");
            }
        }
    }
}

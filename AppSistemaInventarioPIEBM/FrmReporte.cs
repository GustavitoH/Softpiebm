using AppSistemaInventarioPIEBM.Reportes;
using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppSistemaInventarioPIEBM
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }
        public string email;
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            ReporteProductoCategoria("");
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }
        string usuario = "";
        string cargo = "";
        public UsuarioLN uln = new UsuarioLN();

        ProductoLN pln = new ProductoLN();
        public void ReporteProductoCategoria(string busqueda)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }
            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario))
                {
                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }

            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario) && c.Fecha.Day == DateTime.Now.Day && c.Fecha.Month == DateTime.Now.Month && c.Fecha.Year == DateTime.Now.Year)
                {

                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;
        }


        private void btnPaciente_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }

            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario) && (DateTime.Now.Date - c.Fecha.Date).Days <= 6)
                {

                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;
        }

        private void btn30dias_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }

            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario) && (DateTime.Now.Date - c.Fecha.Date).Days <= 29)
                {

                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }

            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario) && c.Fecha.Month == DateTime.Now.Month && c.Fecha.Year == DateTime.Now.Year)
                {

                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uln.MostrarUsuarioFitro("").Count; i++)
            {
                if (uln.MostrarUsuarioFitro("")[i].Email.Equals(email))
                {
                    usuario = uln.MostrarUsuarioFitro("")[i].User;
                    cargo = uln.MostrarUsuarioFitro("")[i].Ocupacion;
                }
            }

            DataSetReporte ds = new DataSetReporte();
            List<VistaReporte> us = pln.MostrarReporteFitro("");
            foreach (VistaReporte c in us)
            {
                if (c.Usuario.Equals(usuario) && c.Fecha.Date >= dateTimePicker1.Value.Date && c.Fecha.Date <= dateTimePicker2.Value.Date)
                {

                    ds.VistaReporte.AddVistaReporteRow(c.ID_Producto, c.Producto, c.Estado, c.Ubicacion, c.Cant, c.Descrip, c.Fecha, (decimal)c.Precio_Aprox, usuario, cargo, email);
                }
            }

            CRReporteArticulos rpa = new CRReporteArticulos();
            rpa.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpa;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

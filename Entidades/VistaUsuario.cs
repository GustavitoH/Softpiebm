namespace Entidades
{
    public class VistaUsuario
    {
        private int iD_Usuario;
        private string usuario;
        private string cargo;

        public VistaUsuario()
        {
        }

        public VistaUsuario(int iD_Usuario, string usuario, string cargo)
        {
            this.iD_Usuario = iD_Usuario;
            this.usuario = usuario;
            this.cargo = cargo;
        }

        public int ID_Usuario { get => iD_Usuario; set => iD_Usuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}

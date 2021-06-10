namespace Entidades
{
    public class Usuario
    {
        private int iD_Usuario;
        private string user;
        private string ocupacion;
        private string email;
        private string contras;

        public Usuario()
        {
        }

        public Usuario(int iD_Usuario, string user, string ocupacion, string email, string contras)
        {
            this.iD_Usuario = iD_Usuario;
            this.user = user;
            this.ocupacion = ocupacion;
            this.email = email;
            this.contras = contras;
        }

        public int ID_Usuario { get => iD_Usuario; set => iD_Usuario = value; }
        public string User { get => user; set => user = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string Email { get => email; set => email = value; }
        public string Contras { get => contras; set => contras = value; }
    }
}

namespace curso.api.Controllers
{       
    internal class UsuarioViewModelOutput
    {
        public UsuarioViewModelOutput()
        {
        }

        public int Codigo { get; internal set; }
        public string Login { get; internal set; }
        public string Email { get; internal set; }
    }
}
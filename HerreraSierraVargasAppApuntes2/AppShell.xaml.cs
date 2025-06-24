namespace HerreraSierraVargasAppApuntes2
{

    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.AgregarEditarRecordatorioPage), typeof(Views.AgregarEditarRecordatorioPage));

        }

    }
}

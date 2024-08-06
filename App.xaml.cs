namespace MauiRfidSample
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get;  private set; }
        public static IServiceCollection Services { get; private set; }
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new AppShell();

            ServiceProvider = serviceProvider;
        }

        public static void AddServiceCollection(IServiceCollection services)
        {
            Services = services;
        }
    }
}

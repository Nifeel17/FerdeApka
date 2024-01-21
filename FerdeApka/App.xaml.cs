using FerdeApka.Pages;

namespace FerdeApka
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EkranWstepny());
        }
    }
}

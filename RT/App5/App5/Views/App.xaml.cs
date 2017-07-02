using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin;
namespace app5.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
 
            MainPage = new MaterDetailPages.MasterDetailPage1();
            
          //  MainPage = new MasterDetailPageNavigation.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

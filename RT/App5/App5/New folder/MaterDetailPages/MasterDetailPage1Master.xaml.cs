using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using app5.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app5.MaterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
        public ListView ListView;

        public MasterDetailPage1Master()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
                    new MasterDetailPage1MenuItem(typeof(Login)) { Id = 0, Title = "Prisijungti" },
                    new MasterDetailPage1MenuItem(typeof(Items)) { Id = 1, Title = "Prekės" },
                    new MasterDetailPage1MenuItem(typeof(MapPage)) { Id = 2, Title = "Parduotuvės" }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
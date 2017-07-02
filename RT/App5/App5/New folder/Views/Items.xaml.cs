using System.Collections.ObjectModel;
using app5.Models;
using Xamarin.Forms;

namespace app5.Views
{
    public partial class Items : ContentPage
    {
      //  private ObservableCollection<Item> ItemsData { get; set; } = new ObservableCollection<Item>();

        //public Items()
        //{
        //    InitializeComponent();
        //    ItemsData.Add(new Itemk("l",55f,"jhg","ghjk"));
        //    ItemsView.ItemsSource = ItemsData;
        //}

        public Items()
        {
            InitializeComponent();

            ItemsView.ItemsSource = GetItems();


        }

        public ObservableCollection<Item> GetItems()
        {
            var lorem = "Lorem ipsum dolor sit  proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            var url = "http://www.sos03.lt/files/images/Bananai%20ir%20antidepresantai.jpg";
            var items = new ObservableCollection<Item>();
            for (int i = 0; i < 500; i++)
            {
                items.Add(new Item(url, 55f, lorem,"Bananas"));
                
            }
            return items;
        }
    }
}

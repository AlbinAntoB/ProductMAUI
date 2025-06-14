using ProductMAUI.ViewModels;

namespace ProductMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

       
    }

}

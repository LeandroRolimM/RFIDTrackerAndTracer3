using MauiRfidSample.MVVM.ViewModels;


namespace MauiRfidSample.MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReaderList : ContentPage
	{
        private readonly ReaderListViewModel _viewmodel;

        public ReaderList()
		{
			InitializeComponent();
            _viewmodel = App.ServiceProvider.GetRequiredService<ReaderListViewModel>();
            BindingContext = _viewmodel ;
            Title = "Readers List";
		}

        private void lvMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _viewmodel.ItemSelected(e.Item);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewmodel.UpdateIn();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewmodel.UpdateOut();
        }
    }
}
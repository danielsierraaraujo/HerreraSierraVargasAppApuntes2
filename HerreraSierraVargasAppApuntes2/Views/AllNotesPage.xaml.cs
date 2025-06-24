using HerreraSierraVargasAppApuntes2.ViewModels;

namespace HerreraSierraVargasAppApuntes2.Views
{
    public partial class AllNotesPage : ContentPage
    {
        public AllNotesPage()
        {
            InitializeComponent();
        }
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is NotesViewModel vm)
            {
                await vm.SaveNotesAsync();
            }
        }
    }
}
using Microsoft.Maui.Controls;
using HerreraSierraVargasAppApuntes2.ViewModels;

namespace HerreraSierraVargasAppApuntes2.Views
{
    public partial class AllNotesPage : ContentPage
    {
        public AllNotesPage()
        {
            InitializeComponent();
            BindingContext = new NotesViewModel();
        }
    }
}

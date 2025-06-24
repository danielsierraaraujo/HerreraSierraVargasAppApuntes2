// ViewModels/NotesViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HerreraSierraVargasAppApuntes2.Models;
using HerreraSierraVargasAppApuntes2.Services;

namespace HerreraSierraVargasAppApuntes2.ViewModels
{
    public partial class NotesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Note> notes;

        [ObservableProperty]
        private string newNoteText;

        public IRelayCommand AddNoteAsyncCommand { get; }
        public IRelayCommand<Note> DeleteNoteAsyncCommand { get; }

        public NotesViewModel()
        {
            Notes = new ObservableCollection<Note>();
            AddNoteAsyncCommand = new RelayCommand(async () => await AddNoteAsync());
            DeleteNoteAsyncCommand = new RelayCommand<Note>(async (note) => await DeleteNoteAsync(note));
            LoadNotesAsync();
        }

        private async void LoadNotesAsync()
        {
            var notesList = await NotesService.LoadNotesAsync();
            foreach (var note in notesList)
            {
                Notes.Add(note);
            }
        }

        private async Task AddNoteAsync()
        {
            if (string.IsNullOrWhiteSpace(NewNoteText)) return;

            var note = new Note
            {
                Filename = Path.GetRandomFileName(),
                Text = NewNoteText,
                Date = DateTime.Now
            };

            Notes.Add(note);
            NewNoteText = string.Empty;

            await NotesService.SaveNotesAsync(Notes.ToList());
        }

        private async Task DeleteNoteAsync(Note note)
        {
            if (Notes.Contains(note))
            {
                Notes.Remove(note);
                await NotesService.SaveNotesAsync(Notes.ToList());
            }
        }
    }
}

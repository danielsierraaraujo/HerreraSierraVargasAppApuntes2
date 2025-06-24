using CommunityToolkit.Mvvm.Input;
using HerreraSierraVargasAppApuntes2.Models;
using HerreraSierraVargasAppApuntes2.Services;
using System.Collections.ObjectModel;
//con ayuda de chat
namespace HerreraSierraVargasAppApuntes2.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; } = new();
        public string NewNoteText { get; set; }

        public IRelayCommand AddNoteAsyncCommand { get; }
        public IRelayCommand<Note> DeleteNoteAsyncCommand { get; }
        public IRelayCommand SaveNotesCommand { get; }

        public NotesViewModel()
        {
            AddNoteAsyncCommand = new RelayCommand(async () => await AddNoteAsync());
            DeleteNoteAsyncCommand = new RelayCommand<Note>(async (note) => await DeleteNoteAsync(note));
            SaveNotesCommand = new RelayCommand(async () => await SaveNotesAsync());
            LoadNotesAsync();
        }

        private async void LoadNotesAsync()
        {
            var notesList = await NotesService.LoadNotesAsync();
            Notes.Clear();
            foreach (var note in notesList)
                Notes.Add(note);
        }

        private async Task AddNoteAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewNoteText))
            {
                var note = new Note
                {
                    Text = NewNoteText,
                    Date = DateTime.Now
                };

                Notes.Add(note);
                await NotesService.SaveNotesAsync(Notes.ToList());
                NewNoteText = string.Empty;
                OnPropertyChanged(nameof(NewNoteText));
            }
        }

        private async Task DeleteNoteAsync(Note note)
        {
            if (Notes.Contains(note))
            {
                Notes.Remove(note);
                await NotesService.SaveNotesAsync(Notes.ToList());
            }
        }

        public async Task SaveNotesAsync()
        {
            await NotesService.SaveNotesAsync(Notes.ToList());
        }
    }
}
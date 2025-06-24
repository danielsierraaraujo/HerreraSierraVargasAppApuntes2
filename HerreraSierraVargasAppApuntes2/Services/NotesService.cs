using System.Text.Json;
using HerreraSierraVargasAppApuntes2.Models;
//con ayuda de gemini
namespace HerreraSierraVargasAppApuntes2.Services
{
    public static class NotesService
    {
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "notes.json");

        public static async Task<List<Note>> LoadNotesAsync()
        {
            if (!File.Exists(FilePath))
                return new List<Note>();

            var json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Note>>(json) ?? new List<Note>();
        }

        public static async Task SaveNotesAsync(List<Note> notes)
        {
            var json = JsonSerializer.Serialize(notes);
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}
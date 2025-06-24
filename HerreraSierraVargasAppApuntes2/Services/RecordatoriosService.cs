using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using HerreraSierraVargasAppApuntes2.Models;

namespace HerreraSierraVargasAppApuntes2.Services
{
    public static class RecordatorioService
    {
        private const string FileName = "recordatorios.json";
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, FileName);

        // Lista compartida de recordatorios
        public static ObservableCollection<Recordatorio> ListaRecordatorios { get; } = new ObservableCollection<Recordatorio>();

        // Carga recordatorios del archivo JSON al ObservableCollection
        public static async Task LoadRecordatoriosAsync()
        {
            if (File.Exists(FilePath))
            {
                var json = await File.ReadAllTextAsync(FilePath);
                var lista = JsonSerializer.Deserialize<ObservableCollection<Recordatorio>>(json);
                if (lista != null)
                {
                    ListaRecordatorios.Clear();
                    foreach (var r in lista)
                        ListaRecordatorios.Add(r);
                }
            }
        }

        // Guarda la lista actual en el archivo JSON
        public static async Task SaveRecordatoriosAsync()
        {
            var json = JsonSerializer.Serialize(ListaRecordatorios);
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}


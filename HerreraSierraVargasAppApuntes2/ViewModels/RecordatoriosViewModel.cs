using System.Collections.ObjectModel;
using System.Windows.Input;
using HerreraSierraVargasAppApuntes2.Models;
using HerreraSierraVargasAppApuntes2.Services;

namespace HerreraSierraVargasAppApuntes2.ViewModels
{
    public class RecordatoriosViewModel : BaseViewModel
    {
        public ObservableCollection<Recordatorio> ListaRecordatorios => RecordatorioService.ListaRecordatorios;

        public ICommand AgregarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }

        public RecordatoriosViewModel()
        {
            AgregarCommand = new Command(async () => await IrAAgregar());
            EditarCommand = new Command<Recordatorio>(async (recordatorio) => await IrAEditar(recordatorio));
            EliminarCommand = new Command<Recordatorio>(async (recordatorio) => await Eliminar(recordatorio));

            _ = InicializarAsync();
        }

        private async Task InicializarAsync()
        {
            await RecordatorioService.LoadRecordatoriosAsync();
            OnPropertyChanged(nameof(ListaRecordatorios));
        }

        private async Task IrAAgregar()
        {
            await Shell.Current.GoToAsync(nameof(Views.AgregarEditarRecordatorioPage));
        }

        private async Task IrAEditar(Recordatorio recordatorio)
        {
            var parametros = new Dictionary<string, object>
            {
                { "RecordatorioSeleccionado", recordatorio }
            };
            await Shell.Current.GoToAsync(nameof(Views.AgregarEditarRecordatorioPage), parametros);
        }

        private async Task Eliminar(Recordatorio recordatorio)
        {
            if (ListaRecordatorios.Contains(recordatorio))
            {
                ListaRecordatorios.Remove(recordatorio);
                await GuardarRecordatoriosAsync();
            }
        }

        public async Task GuardarRecordatoriosAsync()
        {
            await RecordatorioService.SaveRecordatoriosAsync();
        }
    }
}

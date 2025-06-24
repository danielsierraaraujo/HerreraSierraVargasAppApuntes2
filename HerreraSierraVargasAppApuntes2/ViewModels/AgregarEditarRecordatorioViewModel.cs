using System;
using System.Collections.Generic;
using System.Windows.Input;
using HerreraSierraVargasAppApuntes2.Models;
using HerreraSierraVargasAppApuntes2.Services;

namespace HerreraSierraVargasAppApuntes2.ViewModels
{
    public class AgregarEditarRecordatorioViewModel : BaseViewModel, IQueryAttributable
    {
        private Recordatorio recordatorioActual = new();
        public Recordatorio RecordatorioActual
        {
            get => recordatorioActual;
            set
            {
                if (recordatorioActual != value)
                {
                    recordatorioActual = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime fechaSeleccionada;
        public DateTime FechaSeleccionada
        {
            get => fechaSeleccionada;
            set
            {
                if (fechaSeleccionada != value)
                {
                    fechaSeleccionada = value;
                    OnPropertyChanged();
                    ActualizarFechaHora();
                }
            }
        }

        private TimeSpan horaSeleccionada;
        public TimeSpan HoraSeleccionada
        {
            get => horaSeleccionada;
            set
            {
                if (horaSeleccionada != value)
                {
                    horaSeleccionada = value;
                    OnPropertyChanged();
                    ActualizarFechaHora();
                }
            }
        }

        private void ActualizarFechaHora()
        {
            RecordatorioActual.FechaHora = FechaSeleccionada.Date + HoraSeleccionada;
        }

        public ICommand GuardarCommand { get; }

        public AgregarEditarRecordatorioViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarAsync());
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("RecordatorioSeleccionado"))
            {
                var recordatorio = query["RecordatorioSeleccionado"] as Recordatorio;
                if (recordatorio != null)
                {
                    RecordatorioActual = recordatorio;
                    FechaSeleccionada = recordatorio.FechaHora.Date;
                    HoraSeleccionada = recordatorio.FechaHora.TimeOfDay;
                }
            }
        }

        private async System.Threading.Tasks.Task GuardarAsync()
        {
            if (!RecordatorioService.ListaRecordatorios.Contains(RecordatorioActual))
            {
                RecordatorioService.ListaRecordatorios.Add(RecordatorioActual);
            }

            await RecordatorioService.SaveRecordatoriosAsync();

            await Shell.Current.GoToAsync("..");
        }
    }
}



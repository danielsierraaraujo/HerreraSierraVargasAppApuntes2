using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HerreraSierraVargasAppApuntes2.Models
{
    public class Recordatorio : INotifyPropertyChanged
    {
        private string texto;
        public string Texto
        {
            get => texto;
            set
            {
                if (texto != value)
                {
                    texto = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime fechaHora;
        public DateTime FechaHora
        {
            get => fechaHora;
            set
            {
                if (fechaHora != value)
                {
                    fechaHora = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool activo;
        public bool Activo
        {
            get => activo;
            set
            {
                if (activo != value)
                {
                    activo = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ActivoTexto));
                }
            }
        }

        public string ActivoTexto => Activo ? "Activado" : "Desactivado";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombreProp = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombreProp));
    }
}


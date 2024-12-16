using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JosueCevallosmiprimerMVVM.ViewModels
{
    public class CambioDivisasViewModel : INotifyPropertyChanged
    {
        private double _valorDolares;
        private double _valorEuros;

        public double ValorDolares
        {
            get => _valorDolares;
            set
            {
                if (_valorDolares != value)
                {
                    _valorDolares = value;
                    OnPropertyChanged();
                    ConvertirDeDolaresAEuros();
                    // Generar eventos para cambiar de dólares a euros
                }
            }
        }

        public double ValorEuros
        {
            get => _valorEuros;
            set
            {
                if (_valorEuros != value)
                {
                    _valorEuros = value;
                    OnPropertyChanged();
                    // Evento para transformar de euros a dólares
                    ConvertirDeEurosADolares();
                }
            }
        }

        // Método para convertir de dólares a euros
        public void ConvertirDeDolaresAEuros()
        {
            ValorEuros = ValorDolares * 0.95;
        }

        // Método para convertir de euros a dólares
        public void ConvertirDeEurosADolares()
        {
            ValorDolares = ValorEuros * 1.05;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Método para notificar cambios en propiedades
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

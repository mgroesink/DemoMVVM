using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoMVVMWithoutToolkit.Models.ViewModels
{
    public class PokemonVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Pokemon _pokemon;
        private string _validationErrors = string.Empty;

        public PokemonVM()
        {
            // Voorbeeld Pokémon
            _pokemon = new Pokemon
            {
                Name = "Pikachu",
                Type = "Electric"
            };
            UpdateCommand = new Command(UpdatePokemon);
        }


        public string Name
        {
            get => _pokemon.Name;
            set
            {
                if (_pokemon.Name != value)
                {
                    _pokemon.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(50, ErrorMessage = "{0} mag maximaal {1} karakters bevatten")]
        public string Type
        {
            get => _pokemon.Type;
            set
            {
                if (_pokemon.Type != value)
                {
                    _pokemon.Type = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand UpdateCommand { get; }
        public string ValidationErrors
        {
            get { return _validationErrors; }
            set
            {
                _validationErrors = value;
                OnPropertyChanged(nameof(ValidationErrors));
            }
        }

        private void UpdatePokemon()
        {
            // Hier kun je bijvoorbeeld een melding tonen of andere logica toevoegen.
            if (App.Current?.MainPage != null)
            {
                App.Current.MainPage.DisplayAlert("Aangepast", $"Pokemon gewijzigd: {Name}, Type: {Type}", "OK");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Validate()
        {
            var validationContext = new ValidationContext(_pokemon);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(_pokemon, validationContext, results, true);

            if (!isValid)
            {
                ValidationErrors = string.Join("\n", results.Select(r => r.ErrorMessage));
            }

            return isValid;
        }

    }
}

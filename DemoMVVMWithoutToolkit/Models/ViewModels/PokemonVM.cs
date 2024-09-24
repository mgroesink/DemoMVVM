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

        public PokemonVM()
        {
            // Voorbeeld Pokémon
            _pokemon = new Pokemon
            {
                Name = "Pikachu",
                Type = "Electric",
                ImageURL = "pokemon1.jpg"
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

        public string ImageURL
        {
            get => _pokemon.ImageURL;
            set
            {
                if (_pokemon.ImageURL != value)
                {
                    _pokemon.ImageURL = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color BackgroundColor
        {
            get
            {
                Random r = new Random();
                return Color.FromRgb(r.Next(255), r.Next(255), r.Next(255));
            }
        }

        public ICommand UpdateCommand { get; }

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

    }
}

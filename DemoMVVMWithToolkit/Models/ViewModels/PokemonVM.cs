using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoMVVMWithToolkit.Models.ViewModels
{
    public partial class PokemonVM : ObservableObject
    {

        /// <summary>
        /// The pokemon
        /// </summary>
        [ObservableProperty]
        private Pokemon _pokemon;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonVM"/> class.
        /// </summary>
        public PokemonVM()
        {
            // Voorbeeld Pokémon
            _pokemon = new Pokemon
            {
                Name = "Pikachu",
                Type = "Electric",
                ImageURL = "pokemon1.jpg"
            };
        }

        /// <summary>
        /// Updates the pokemon.
        /// </summary>
        [RelayCommand]
        private void UpdatePokemon()
        {
            // Hier kun je bijvoorbeeld een melding tonen of andere logica toevoegen.
            if (App.Current?.MainPage != null)
            {
                App.Current.MainPage.DisplayAlert("Aangepast", $"Pokemon gewijzigd: {Pokemon.Name}, Type: {Pokemon.Type}", "OK");
            }
        }
    }
}

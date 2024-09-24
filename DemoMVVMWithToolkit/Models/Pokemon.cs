using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVVMWithToolkit.Models
{

    public partial class Pokemon: ObservableObject
    {
        /// <summary>
        /// The name
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;
        /// <summary>
        /// The type
        /// </summary>
        [ObservableProperty] 
        private string type = string.Empty;
        /// <summary>
        /// The image URL
        /// </summary>
        [ObservableProperty] 
        private string imageURL = string.Empty;
    }
}

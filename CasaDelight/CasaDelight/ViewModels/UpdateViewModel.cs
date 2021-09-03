using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.ViewModels
{
    public class UpdateViewModel : CreateViewModel
    {
        public int Id { get; set; }
        public string ExistingImage { get; set; }
    }
}

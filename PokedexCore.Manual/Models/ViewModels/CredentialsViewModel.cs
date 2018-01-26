using FluentValidation.Attributes;
using PokedexCore.Manual.Models.Validations;

namespace PokedexCore.Manual.Models.ViewModels {
    [Validator( typeof( CredentialsViewModelValidator ) )]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

using FluentValidation.Attributes;
using PokedexCore.Manual.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace PokedexCore.Manual.Models.ViewModels {
    [Validator( typeof( RegistrationViewModelValidator ) )]
    public class RegistrationViewModel {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
    }
}

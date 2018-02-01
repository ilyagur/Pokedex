using FluentValidation;
using PokedexCore.Manual.Models.ViewModels;

namespace PokedexCore.Manual.Models.Validations {
    public class RegistrationViewModelValidator: AbstractValidator<RegistrationViewModel> {
        public RegistrationViewModelValidator() {
            RuleFor( vm => vm.Email ).EmailAddress().WithMessage("Please enter valid email");
            RuleFor( vm => vm.Password ).NotEmpty().WithMessage( "Password cannot be empty" );
            RuleFor( vm => vm.Password ).Length( 6, 12 ).WithMessage( "Password must be between 6 and 12 characters" );
            RuleFor( vm => vm.FirstName ).NotEmpty().WithMessage( "FirstName cannot be empty" );
            RuleFor( vm => vm.LastName ).NotEmpty().WithMessage( "LastName cannot be empty" );
        }
    }
}

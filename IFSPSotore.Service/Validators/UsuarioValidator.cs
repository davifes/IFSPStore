using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPSotore.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor informe o nome.")
                .NotNull().WithMessage("Por favor informe o nome.");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-mail invalido")
                .NotEmpty().WithMessage("Por favor informe o email.")
                .NotNull().WithMessage("Por favor informe o email.");

            RuleFor(c => c.Senha)
                .MinimumLength(8).WithMessage("Sua senha tem q ter no minimo 8 caracteres.")
                .MaximumLength(8).WithMessage("Sua senha tem q ter no maximo 16 caracteres.")
                .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter no minimo uma letra maiuscula.")
                .Matches(@"[a-z]+").WithMessage("Sua senha deve conter no minimo uma letra minuscula.")
                .Matches(@"[0-9]+").WithMessage("Sua senha deve conter no minimo um numeral.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Sua senha deve conter um caracter especial (! ? * . ).")
                .NotEmpty().WithMessage("Por favor informe a senha.")
                .NotNull().WithMessage("Por favor informe a senha.");
        }
    }
}

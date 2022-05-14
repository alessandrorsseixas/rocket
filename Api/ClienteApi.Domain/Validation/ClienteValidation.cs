using ClienteApi.Domain.Entities;
using FluentValidation;

namespace ClienteApi.Valitation
{
    public class ClienteValidation : EntityValidation<Cliente>
    {
        public ClienteValidation()
        {
           
            RuleFor(c => c.Nome)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                 .WithName("Nome");

            RuleFor(c => c.Porte)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(1, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                 .WithName("Porte");

            //RuleFor(c => c.UpdateAt)
            // .NotNull()
            // .Must(BeAUpdateDateIsValideDate).When(x => x.UpdateAt > x.CreateAt)
            // .WithName("Data de Atualização");
        }

    }
}

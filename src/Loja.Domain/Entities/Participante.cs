using churrascaria.Entities;
using Churrascaria.Domain.Utils;
using FluentValidation;

namespace Churrascaria.Domain
{
    public class Participante : Entity<Participante>
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull()
            .MaximumLength(Constantes.QuantidadeDeCaracteres100);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

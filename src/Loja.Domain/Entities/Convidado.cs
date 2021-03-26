using churrascaria.Entities;
using Churrascaria.Domain.Utils;
using FluentValidation;
using FluentValidation.Results;

namespace Churrascaria.Domain
{
    public class Convidado : Entity<Convidado>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool VaiBeber { get; set; }
        public decimal ValorConvidado { get; private set; }
        public string Telefone { get; set; }
        public Funcionario Funcionario { get; set; }

        public Convidado(string nome, int idade, bool vaiBeber)
        {
            Nome = nome;
            Idade = idade;
            VaiBeber = vaiBeber;

            Validar();
            ValidaSeVaiBeber();
        }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
             .NotEmpty()
             .NotNull()
             .MaximumLength(Constantes.QuantidadeDeCaracteres100);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void ValidaSeVaiBeber()
        {
            if (VaiBeber == true)
                ValorConvidado = 40;
            else { ValorConvidado = 20; }
        }
    }
}

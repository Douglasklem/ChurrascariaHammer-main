using System.Collections.Generic;
using churrascaria.Entities;
using Churrascaria.Domain.Utils;
using FluentValidation;

namespace Churrascaria.Domain
{
    public class Funcionario : Entity<Funcionario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int ParticipanteId { get; set; }
        public int ConvidadoId { get; set; }
        public string Telefone { get; set; }
        public decimal ValorFuncionario { get; private set; }
        public bool VaiBeber { get; set; }
        public ICollection<Participante> Participante { get; set; }
        public Convidado Convidado { get; set; }

        public Funcionario(string nome, int idade, bool vaiBeber)
        {
            Nome = nome;
            Idade = idade;
            VaiBeber = vaiBeber;

            Validar();
            ValidaSeVaiBeber();
        }

        public void ValidaSeVaiBeber()
        {
            if (VaiBeber == true)
                ValorFuncionario = 20;
            else { ValorFuncionario = 10; }

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
    }
}

using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace va.technical.challenge.domain.Dtos.Divisor
{
    public class DivisorRequest
    {
        public DivisorRequest(int numero)
        {
            Numero = numero;
        }

        public int Numero { get; private set; }

        public bool IsValid { get; protected set; }
        public ModelStateDictionary ErrosModelState { get; protected set; }

        public async Task<DivisorRequest> ValidarAsync(ModelStateDictionary modelState)
        {
            ErrosModelState = modelState;
            var validacao = await new DivisorRequestValidator().ValidateAsync(this);
            IsValid = validacao.IsValid;
            foreach (var erro in validacao.Errors)
                ErrosModelState.AddModelError(Guid.NewGuid().ToString(), erro.ErrorMessage);

            if (!ErrosModelState.IsValid)
                throw await Task.FromResult(new ArgumentException());

            return this;
        }
    }

    public class DivisorRequestValidator : AbstractValidator<DivisorRequest>
    {
        public DivisorRequestValidator()
        {
            RuleFor(x => x.Numero)
                .GreaterThan(0)
                .WithMessage("O campo número deve ser maior que zero.");
        }
    }
}

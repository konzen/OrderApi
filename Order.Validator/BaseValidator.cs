using FluentValidation;

namespace Order.Validator
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected const string digits = @"^[0-9]+$";
        protected const string digitsHex = @"^[0-9A-F]+$";
        protected const string dateTimeExpression = @"^[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}(\.[0-9]{3})?$";
        protected const string invalidValue = "'{PropertyName}' não tem um valor válido.";
    }
}

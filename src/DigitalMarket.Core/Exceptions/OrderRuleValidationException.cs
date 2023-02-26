using DigitalMarket.Core.Rules;

namespace DigitalMarket.Core.Exceptions;

public class OrderRuleValidationException : Exception
{
    public IBusinessRule BrokenRule { get; }

    public string Details { get; }

    public OrderRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        this.Details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}
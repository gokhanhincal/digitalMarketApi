using DigitalMarket.Core.Exceptions;

namespace DigitalMarket.Core.Rules;

public class CheckRules
{
    public static void Apply(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new OrderRuleValidationException(rule);
        }
    }
}
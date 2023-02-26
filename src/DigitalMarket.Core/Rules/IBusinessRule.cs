namespace DigitalMarket.Core.Rules;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}
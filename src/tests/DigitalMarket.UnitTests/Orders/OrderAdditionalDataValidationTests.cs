using DigitalMarket.Core.Rules;
using DigitalMarket.UnitTests.SeedWork;
using Xunit;

namespace DigitalMarket.UnitTests.Orders;

public class OrderAdditionalDataValidationTests
{
    [Fact]
    public void GivenValidOrderProduct_WhenPartnerCreateOrder_Throws_No_Exception()
    {
        // Arrange
        var model = TestData.CreateWebsiteOrderWithInsufficientAdditionalInfo();

        //Act
        var ruleToApply = new OrderCreationRule(model);
        var caughtException =  Record.Exception(() => CheckRules.Apply(ruleToApply));

        // Assert
        Assert.Null(caughtException);
    }
}
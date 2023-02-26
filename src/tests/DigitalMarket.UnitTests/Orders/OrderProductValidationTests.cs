using DigitalMarket.Core.Exceptions;
using DigitalMarket.Core.Rules;
using DigitalMarket.UnitTests.SeedWork;
using Xunit;

namespace DigitalMarket.UnitTests.Orders;

public class OrderProductValidationTests
{
    
    [Fact]
    public void GivenValidOrderProduct_WhenPartnerCreateOrder_Throws_No_Exception()
    {
        //Arrange
        var model = TestData.CreateWebsiteOrderModel();

        //Act
        var ruleToApply = new OrderCreationRule(model);
        var caughtException =  Record.Exception(() => CheckRules.Apply(ruleToApply));

        //Assert
        Assert.Null(caughtException);
    }
    
    [Fact]
    public void GivenValidOrderProduct_WhenPartnerCreateOrder_Throws_OrderRuleValidationException()
    {
        //Arrange
        var model = TestData.CreateInvalidProductForPartner();

        //Act
        var ruleToApply = new OrderCreationRule(model);
        var caughtException = Record.Exception(() => CheckRules.Apply(ruleToApply));
     
        // Assert
        Assert.IsType<OrderRuleValidationException>(caughtException);
    }
}
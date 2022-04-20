using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace CreateProduct.Tests;

public class FunctionTest
{
    [Fact]
    public void TestCreateProductFunction()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Function();
        var context = new TestLambdaContext();
        var productRequest = new CreateProductRequest();
        productRequest.Name = "iPhone 13";
        productRequest.Description = "Premium Smartphone";
        var response = function.FunctionHandler(productRequest, context);

        Assert.Equal(productRequest.Name, response.Name);
        Assert.Equal(productRequest.Description, response.Description);
        Assert.NotEmpty(response.ProductId);
    }
}

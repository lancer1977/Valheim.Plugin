using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework; 
using PolyhydraGames.Core.Test;

namespace PolyhydraGames.RCon.Test;

[TestFixture]
public partial class ValheimIntegratedTests
{ 
#pragma warning disable NUnit1032
    public IHost App { get; set; }
#pragma warning restore NUnit1032
    public ValheimIntegratedTests()
    { 
        App = TestHelpers.GetHost((x, services) =>
        {
            services.AddSingleton<HttpClient>(); 
        }); 
    }
    [OneTimeSetUp]
    public async Task SetUp()
    { 
    }

 

    [OneTimeTearDown]
    public void TearDown()
    { 
    }
    private void ProcessResult()//RestResult result, string successMessage = "", string errorMessage = "")
    {
        //Console.WriteLine(result.OutgoingMessage);
        //Console.WriteLine(result.Response);
        //if (!result.Successful) Console.WriteLine(errorMessage);
        //Assert.That(result.Successful, successMessage);
    }
}
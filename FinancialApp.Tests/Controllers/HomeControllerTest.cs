using FinancialApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class HomeControllerTest
{
    [Test]
    public void IndexCase01()
    {
        // AAA -> Arrange, Act, Assert
        //Arrange 
        var controller = new HomeController();
        // Act
        var view = controller.Index() as ViewResult;
        // Assert
        Assert.IsNotNull(view); 
        // Assert.IsInstanceOf<List<User>>(view.Model);
        // Assert.IsTrue(view.ViewData.ContainsKey("Personas"));
    }
    
    [Test]
    public void PrivacyCase01()
    {
        var controller = new HomeController();
        var view = controller.Privacy() as ViewResult;
        Assert.IsNotNull(view); 
        Assert.IsNull(view.Model);
    }
}
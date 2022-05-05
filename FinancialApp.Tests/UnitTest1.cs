using System;
using FinancialApp.Web;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests;

public class Tests
{
    private Mock<ITipoCambio> mock; 
    
    [SetUp]
    public void SetUp()
    {
        mock = new Mock<ITipoCambio>();
        mock.Setup(o => o.GetTipoCambioSoles()).Returns(3.76m);

        Console.WriteLine("SetUp");
    }
    
    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("TearDown");
    }

    [Test]
    public void Test1()
    {
        
        var calc = new Calculadora(mock.Object);
        var total = calc.GetMontoTotalEnSoles(100);
        
        Assert.AreEqual(376m, total);
    }
    
    [Test]
    public void Test4()
    {
        mock.Setup(o => o.GetTipoCambioSoles()).Returns(3.77m);
        
        var calc = new Calculadora(mock.Object);
        var total = calc.GetMontoTotalEnSoles(100);
        
        Assert.AreEqual(377m, total);
    }
    
    [Test]
    public void Test2()
    {
        var calc = new Calculadora(mock.Object);
        var total = calc.GetMontoTotalEnSoles(200);
        
        Assert.AreEqual(752m, total);
    }
    
    [Test]
    public void Test3()
    {
        var calc = new Calculadora(mock.Object);
        var total = calc.GetMontoTotalEnSoles(1);
        
        Assert.AreEqual(3.76m, total);
    }
}
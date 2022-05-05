using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using FinancialApp.Web.Controllers;
using FinancialApp.Web.Models;
using FinancialApp.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new CuentaController(mockTipoRepositorio.Object, null, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }
    
    [Test]
    public void EditViewCase01()
    { 
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerCuentaPorId(2)).Returns(new Cuenta{Id = 1, Nombre = "Joel", Monto = 25});
        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        var view = (ViewResult)controller.Edit(2);
        
        Assert.IsNotNull(view.Model);
        Assert.IsNotNull(view);
       
    }

    [Test]
    public void IndexViewCase01()
    {
        //paso 6.- Creamos un mock de ClaimsPrincipal
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        // paso 7.- Configuramos el claims
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim> {new Claim(ClaimTypes.Name, "admin")});
        
        
        //paso 4.- Creamos el mock del HttpContex
        var mockContex = new Mock<HttpContext>();
        //paso 5.- Configuramos el metodo user
        mockContex.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);
        
        //paso 8.- Creamos mock Cuenta Repositorio
        var mockCuentaRepo = new Mock<ICuentaRepositorio>();
        mockCuentaRepo.Setup(o => o.ObtenerCuentasDeUsuario(1)).Returns(new List<Cuenta>
        {
            new Cuenta()
        });
        
        //paso 1.- Instanciar a la clase CuentaController
        var controller = new CuentaController(null, mockCuentaRepo.Object, null);
        // paso 3.- Corrigiendo el null del httpContex
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };
        
        //Paso 2.- Instanciamos al metodo
        var view = (ViewResult)controller.Index();

        
        Assert.IsNotNull(view);
        Assert.AreEqual(1, ((List<Cuenta>) view.Model).Count);
    }

    
    [Test]
    public void postCrearCase1Ok()
    {
        
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        // paso 7.- Configuramos el claims
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim> {new Claim(ClaimTypes.Name, "admin")});
        
        var mockContex = new Mock<HttpContext>();
        mockContex.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockRepositorio = new Mock<ICuentaRepositorio>();
       
        var controller = new CuentaController(null, mockRepositorio.Object, null);
         
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };
        
        
        var result = controller.Create(new Cuenta(){TipoCuentaId = 2});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }
    
    [Test]
    public void postCrearCharsh()
    {
        
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        // paso 7.- Configuramos el claims
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim> {new Claim(ClaimTypes.Name, "admin")});
        
        var mockContex = new Mock<HttpContext>();
        mockContex.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockRepositorio = new Mock<ICuentaRepositorio>();

        var mockTipoCuentaRepo = new Mock<ITipoCuentaRepositorio>();
       
        var controller = new CuentaController(mockTipoCuentaRepo.Object, mockRepositorio.Object, null);
         
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContex.Object
        };
        
        
        var result = controller.Create(new Cuenta(){TipoCuentaId = 7});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<ViewResult>(result);
    }
}
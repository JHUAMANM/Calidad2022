using System.Linq;
using FinancialApp.Web.Models;
using FinancialApp.Web.DB;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Web.Repositories;

public interface ICuentaRepositorio
{
    Cuenta ObtenerCuentaPorId(int id);
    List<Cuenta> ObtenerCuentasDeUsuario(int UserId);
    void GuardarCuenta(Cuenta cuenta);
}

public class CuentaRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public CuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    public Cuenta ObtenerCuentaPorId(int id)
    {
      return _dbEntities.Cuentas.First(o => o.Id == id); // lambdas / LINQ
       
    }

    public List<Cuenta> ObtenerCuentasDeUsuario(int UserId)
    {
        return _dbEntities.Cuentas
            .Include(o => o.TipoCuenta)
            .Where(o => o.UsuarioId == UserId).ToList();
    }

    public void GuardarCuenta(Cuenta cuenta)
    {
        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
    }
    
}
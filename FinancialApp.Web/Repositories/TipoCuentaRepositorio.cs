using FinancialApp.Web.DB;
using FinancialApp.Web.Models;

namespace FinancialApp.Web.Repositories;

public interface ITipoCuentaRepositorio
{
    List<TipoCuenta> ObtenerTodos();
}

public class TipoCuentaRepositorio: ITipoCuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public TipoCuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    public List<TipoCuenta> ObtenerTodos()
    {
        return _dbEntities.TipoCuentas.ToList();
    }
}
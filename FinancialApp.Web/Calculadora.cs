namespace FinancialApp.Web;

public interface ITipoCambio
{
    decimal GetTipoCambioSoles();
    decimal GetTipoCambioEuros();
}
public class TipoCambio: ITipoCambio
{
    public decimal GetTipoCambioSoles()
    {
        // conectarse a los servidores de sunata para obtener el tipo de cambio actual
        throw new Exception("No nos podemos conectar al servidor de SUNAT");
        return 3.763m;
    }
    
    public decimal GetTipoCambioEuros()
    {
        // conectarse a los servidores de sunata para obtener el tipo de cambio actual
        // throw new Exception("No nos podemos conectar al servidor de SUNAT");
        return 3.76m;
    }
}

public class TipoCambio2 : ITipoCambio
{
    public decimal GetTipoCambioSoles()
    {
        throw new NotImplementedException();
    }

    public decimal GetTipoCambioEuros()
    {
        throw new NotImplementedException();
    }
}

public class Calculadora
{
    private ITipoCambio _tipoCambio;
    public Calculadora(ITipoCambio tipoCambio)
    {
        _tipoCambio = tipoCambio;
    }
    public decimal GetMontoTotalEnSoles(decimal montoDolares)
    {
        // var tipo = new TipoCambio().GetTipoCambioSoles()
        return montoDolares * _tipoCambio.GetTipoCambioSoles();
    }
}

public class Main
{
    public void Init()
    {
        var tipoDeCambio = new TipoCambio();
        var calculadora = new Calculadora(tipoDeCambio);

        calculadora.GetMontoTotalEnSoles(100);
    }
}
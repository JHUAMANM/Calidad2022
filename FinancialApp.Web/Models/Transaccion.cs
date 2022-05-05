namespace FinancialApp.Web.Models;

public class Transaccion
{
    public int Id { get; set; }
    public int CuentaId { get; set; } // siempre enviar
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; }
    public decimal Monto { get; set; }
    public string Nota { get; set; }
}
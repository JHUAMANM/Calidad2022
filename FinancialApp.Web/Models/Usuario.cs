namespace FinancialApp.Web.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } // password -> 123456 -> no se debe guaradr como dato -> hash
}
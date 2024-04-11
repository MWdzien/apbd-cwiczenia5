namespace WebApplication1.Models;

public class Visit
{
    public string Date { get; set; }
    public Animal Animal { get; set; }
    public string VisitDescription { get; set; }
    public int Price { get; set; }
}
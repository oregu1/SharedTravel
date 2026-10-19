namespace SharedTravel.Models;

public class Trip
{
    //  FIELDS
    public Guid  Id { get; set; } = Guid.NewGuid(); // TODO: Change it via SQL or another way
    public string Name { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CountryCode Country { get; set; } = CountryCode.US;
    public CurrencyCode CurrencyCode { get; set; } = CurrencyCode.USD;
    public decimal PlannedBudget { get; set; }

    //  COLLECTIONS
    public List<City> Cities { get; set; } = new List<City>();
    public List<Participant> Participants { get; set; } = new List<Participant>();
    public List<Expense> Expenses { get; set; } = new List<Expense>();
    public List<Settlement> Settlements { get; set; } = new List<Settlement>();
}
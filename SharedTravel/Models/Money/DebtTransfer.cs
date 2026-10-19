namespace SharedTravel.Models;

public class DebtTransfer
{
    public Participant From { get; set; } = null!;
    public Participant To { get; set; } = null!;
    public decimal Amount { get; set; }
}
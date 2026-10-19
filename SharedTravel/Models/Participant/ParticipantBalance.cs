namespace SharedTravel.Models;

public class ParticipantBalance
{
    public Participant Participant { get; set; } = null!;
    public decimal TotalPaid { get; set; }    // сколько заплатил
    public decimal TotalOwed { get; set; }    // сколько составляют его доли
    public decimal Balance => TotalPaid - TotalOwed;   // плюс переводы
}
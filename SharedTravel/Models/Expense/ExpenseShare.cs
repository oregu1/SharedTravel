namespace SharedTravel.Models;

public class ExpenseShare
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }   // сколько этот человек "потребил"

    public Guid ExpenseId { get; set; }
    public Expense? Expense { get; set; }

    public Guid ParticipantId { get; set; }
    public Participant? Participant { get; set; }
}
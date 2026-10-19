namespace SharedTravel.Models;

public class Expense
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public SplitType SplitType { get; set; }        // как делили (для отображения и редактирования)

    public Guid TripId { get; set; }
    public Trip? Trip { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Guid PaidByParticipantId { get; set; }   // кто платил
    public Participant? PaidBy { get; set; }

    public List<ExpenseShare> Shares { get; set; } = new();
}
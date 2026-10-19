namespace SharedTravel.Models;

public class Settlement
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Guid TripId { get; set; }
    public Trip? Trip { get; set; }

    public Guid FromParticipantId { get; set; }     // кто вернул
    public Participant? From { get; set; }

    public Guid ToParticipantId { get; set; }       // кому вернули
    public Participant? To { get; set; }
}
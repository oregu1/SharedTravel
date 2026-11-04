using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTravel.Models;

public class Settlement
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Guid TripId { get; set; }
    public Trip? Trip { get; set; }

    
    // Каждый атрибут связывает ссылку на объект с конкретным идентификатором. Теперь EF Core получает явное указание искать отправителя по FromParticipantId, а получателя — по ToParticipantId
    public Guid FromParticipantId { get; set; }     // кто вернул
    [ForeignKey(nameof(FromParticipantId))] // привязка FromParticipantId к From
    public Participant? From { get; set; }

    public Guid ToParticipantId { get; set; }       // кому вернули
    [ForeignKey(nameof(ToParticipantId))] // привязка ToParticipantId к To
    public Participant? To { get; set; }
    
}
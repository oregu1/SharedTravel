namespace SharedTravel.Models;

public class Participant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TripId { get; set; }
    public string Name { get; set; } = "";
    public bool IsMe { get; set; }
}
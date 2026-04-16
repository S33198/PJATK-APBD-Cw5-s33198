namespace ASP.Models;

public class Reservations
{
    public int Id { get; set; }
    public int RoomId {get; set;}
    public int OrganizerName {get; set;}
    public string Topic {get; set;}
    public DateTime Date {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}
    public Status Status {get; set;}
}
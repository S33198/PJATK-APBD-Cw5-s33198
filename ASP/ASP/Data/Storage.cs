using ASP.Models;

namespace ASP.Data;

public class Storage
{
    public static List<Reservations> reservations;
    public static List<Room> rooms;

   
    //Przykladowe dane wygenerowane w chatGPT (jak nie mozna to przepraszam)
    public static void GenerateData()
    {
        rooms = new List<Room>
{
    new Room { Id = 1, Name = "Sala A", BuildingCode = "A", Floor = 1, Capacity = 10, HasProjector = true, IsActive = true },
    new Room { Id = 2, Name = "Sala B", BuildingCode = "A", Floor = 2, Capacity = 20, HasProjector = false, IsActive = true },
    new Room { Id = 3, Name = "Sala C", BuildingCode = "B", Floor = 1, Capacity = 15, HasProjector = true, IsActive = true },
    new Room { Id = 4, Name = "Sala D", BuildingCode = "B", Floor = 3, Capacity = 25, HasProjector = true, IsActive = false },
    new Room { Id = 5, Name = "Sala E", BuildingCode = "C", Floor = 2, Capacity = 30, HasProjector = false, IsActive = true }
};

reservations = new List<Reservations>
{
    new Reservations { Id = 1, RoomId = 1, OrganizerName = 101, Topic = "Spotkanie zespołu", Date = DateTime.Today, StartTime = new DateTime(2026, 1, 1, 10, 0, 0), EndTime = new DateTime(2026, 1, 1, 15, 0, 0), Status = Status.Planned },
    new Reservations { Id = 2, RoomId = 2, OrganizerName = 102, Topic = "Prezentacja projektu", Date = DateTime.Today, StartTime = DateTime.Today.AddHours(10), EndTime = DateTime.Today.AddHours(11), Status = Status.Confirmed },
    new Reservations { Id = 3, RoomId = 3, OrganizerName = 103, Topic = "Szkolenie", Date = DateTime.Today, StartTime = DateTime.Today.AddHours(11), EndTime = DateTime.Today.AddHours(13), Status = Status.Planned },
    new Reservations { Id = 4, RoomId = 4, OrganizerName = 104, Topic = "Warsztaty", Date = DateTime.Today, StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(12), Status = Status.Cancelled },
    new Reservations { Id = 5, RoomId = 5, OrganizerName = 105, Topic = "Spotkanie HR", Date = DateTime.Today, StartTime = DateTime.Today.AddHours(13), EndTime = DateTime.Today.AddHours(14), Status = Status.Planned },

    new Reservations { Id = 6, RoomId = 1, OrganizerName = 106, Topic = "Daily Scrum", Date = DateTime.Today.AddDays(1), StartTime = DateTime.Today.AddDays(1).AddHours(9), EndTime = DateTime.Today.AddDays(1).AddHours(9.5), Status = Status.Planned },
    new Reservations { Id = 7, RoomId = 2, OrganizerName = 107, Topic = "Demo", Date = DateTime.Today.AddDays(1), StartTime = DateTime.Today.AddDays(1).AddHours(10), EndTime = DateTime.Today.AddDays(1).AddHours(11), Status = Status.Confirmed },
    new Reservations { Id = 8, RoomId = 3, OrganizerName = 108, Topic = "Retrospektywa", Date = DateTime.Today.AddDays(1), StartTime = DateTime.Today.AddDays(1).AddHours(11), EndTime = DateTime.Today.AddDays(1).AddHours(12), Status = Status.Planned },
};
    }
}
using ASP.Data;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers;

public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetReservations()
    {
        return Ok(Storage.reservations);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var reservation = Storage.reservations.FirstOrDefault(x => x.Id == id);
        if (reservation == null)
            return NotFound(new {message = " Reservation not found "});
        return Ok(reservation);
    }

    [HttpGet("api/reservations")]
    public IActionResult GetReservations(
        [FromQuery] DateTime date,
        [FromQuery] Status status,
        [FromQuery] int roomId)
    {
        var reservation = Storage.reservations.
            Where(r => r.Date == date).
            Where(r => r.Status == status).
            Where(r => r.RoomId == roomId).ToList();
        if (reservation == null)
            return NotFound(new {message = " Reservation not found "});
        return Ok(reservation);
    }
    [HttpPost]
    public IActionResult CreateReservation([FromBody] Reservations reservation)
    {
        reservation.Id = Storage.reservations.Count + 1;
        Storage.reservations.Add(reservation);
        return Ok(reservation);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateReservation(int id, [FromBody] Reservations reservation)
    {
        var LoadedReservation = Storage.reservations.FirstOrDefault(r => r.Id == id);
        if(LoadedReservation == null)
            return NotFound();
        LoadedReservation.Id = reservation.Id;
        LoadedReservation.RoomId = reservation.RoomId;
        LoadedReservation.OrganizerName = reservation.OrganizerName;
        LoadedReservation.Topic = reservation.Topic;
        LoadedReservation.Date = reservation.Date;
        LoadedReservation.StartTime = reservation.StartTime;
        LoadedReservation.EndTime = reservation.EndTime;
        LoadedReservation.Status = reservation.Status;
        return Ok(LoadedReservation);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(int id)
    {
        var reservation = Storage.reservations.FirstOrDefault(r => r.Id == id);
        if(reservation == null)
            return NotFound();
        Storage.reservations.Remove(reservation);
        return NoContent();
    }
}
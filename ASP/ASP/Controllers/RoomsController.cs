using ASP.Data;
using Microsoft.AspNetCore.Mvc;
using ASP.Models;

namespace ASP.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetRooms()
    {
        return Ok(Storage.rooms);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var room = Storage.rooms.FirstOrDefault(x => x.Id == id);
        if (room == null)
            return NotFound(new {message = " Room not found "});
        return Ok(room);
    }

    [HttpGet("building/{BuildingCode}")]
    public IActionResult GetByBuildingId(string buildingcode)
    {
        var rooms = Storage.rooms.Where(x => x.BuildingCode == buildingcode).ToList();
        if (rooms.Count == 0)
            return NotFound(new {message = " Rooms in the building not found "});
        return Ok(rooms);
    }

    [HttpGet("filter")]
    public IActionResult GetFiltered(int? mincapacity, bool? hasprojector, bool? activeonly)
    {
        var rooms = Storage.rooms.AsQueryable();
        if(mincapacity.HasValue)
            rooms = rooms.Where(r=> r.Capacity>=mincapacity.Value);
        if (hasprojector.HasValue)
            rooms = rooms.Where(r=> r.HasProjector == hasprojector.Value);
        if (activeonly.HasValue && activeonly.Value)
            rooms = rooms.Where(r=>r.IsActive);
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult CreateRoom([FromBody] Room room)
    {
        room.Id = Storage.rooms.Count + 1;
        Storage.rooms.Add(room);
        return Ok(room);
    }
    [HttpPut"{id}"]

    public IActionResult UpdateRoom(int id, [FromBody] Room room)
    {
        var LoadedRoom = Storage.rooms.FirstOrDefault(r => r.Id == id);
        if(LoadedRoom == null)
            return NotFound();
        LoadedRoom.Name = room.Name;
        LoadedRoom.Capacity = room.Capacity;
        LoadedRoom.IsActive = room.IsActive;
        LoadedRoom.Capacity = room.Capacity;
        LoadedRoom.BuildingCode = room.BuildingCode;
        LoadedRoom.HasProjector = room.HasProjector;
        return Ok(LoadedRoom);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = Storage.rooms.FirstOrDefault(r => r.Id == id);
        if(room == null)
            return NotFound();
        Storage.rooms.Remove(room);
        return NoContent();
    }
    
    
    
    
    
}
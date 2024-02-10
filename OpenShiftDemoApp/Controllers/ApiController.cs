using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OpenShiftDemoApp.Models;

namespace OpenShiftDemoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    [HttpGet("/users")]
    public async Task<IActionResult> Users()
    {
        await using var fileStream = System.IO.File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json"));
        var users = await JsonSerializer.DeserializeAsync<List<User>>(fileStream);

        return Ok(users);
    }
    
    [HttpGet("/photos")]
    public async Task<IActionResult> Photos([FromQuery] int limit = 100)
    {
        await using var fileStream = System.IO.File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "photos.json"));
        var photos = await JsonSerializer.DeserializeAsync<List<Photo>>(fileStream);

        return Ok(photos?.Take(limit).ToList() ?? []);
    }
}
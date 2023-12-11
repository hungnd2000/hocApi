using apiBt1.Models;
using apiBT1.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace apiBT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController: ControllerBase
{
    private readonly DataRepository _dataRepository;

    public DataController(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    [HttpPost("save")]
    public IActionResult SaveData(Text inputData)
    {
        var json = JsonSerializer.Serialize(inputData);
        _dataRepository.SaveData(json);
        return Ok("Data saved successfully");
    }

    [HttpGet("read")]
    public IActionResult ReadData()
    {
        var data = _dataRepository.ReadData();
        return Ok(data);
    }
}
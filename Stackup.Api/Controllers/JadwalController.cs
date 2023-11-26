using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using ZstdSharp.Unsafe;

[Route("api/[controller]")]
[ApiController]
public class Jadwal_MapelController : ControllerBase
{
    private readonly DbJadwalMapel _dbJadwalMapel;
    Response response = new Response();

    public Jadwal_MapelController(IConfiguration configuration)
    {
        _dbJadwalMapel = new DbJadwalMapel(configuration);
    }

    [HttpGet]
    public IActionResult GetJadwal()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbJadwalMapel.GetAllJadwal();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateJadwal([FromBody] Jadwal jadwal)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            _dbJadwalMapel.CreateJadwal(jadwal);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJadwal(int id, [FromBody] Jadwal jadwal)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            _dbJadwalMapel.UpdateJadwal(id, jadwal);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJadwal(int id)
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            _dbJadwalMapel.DeleteJadwal(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}
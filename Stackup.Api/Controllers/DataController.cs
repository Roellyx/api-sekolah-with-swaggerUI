using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class DataController : ControllerBase
{
    
    private readonly DbData _dbData;
    Response response = new Response();

    public DataController(IConfiguration configuration)
    {
        _dbData = new DbData(configuration);
    }


    [HttpGet("Hari")]
    public IActionResult GetHari()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbData.GetAllHari();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("Jam")]
    public IActionResult GetJam()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbData.GetAllJam();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("Kelas")]
    public IActionResult GetKelas()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbData.GetAllKelas();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}
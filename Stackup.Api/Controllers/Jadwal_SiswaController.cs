using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]
public class Jadwal_SiswaController : ControllerBase
{
    private readonly DbJadwalSiswa _dbJadwalSiswa;
    Response response = new Response();

    public Jadwal_SiswaController(IConfiguration configuration)
    {
        _dbJadwalSiswa = new DbJadwalSiswa(configuration);
    }


    // GET: api/Ambil Jadwal Pelajaran Sesuai Nama
    [HttpGet]
    public IActionResult GetPelajaran([FromQuery] string nama)
    {
        try{
            response.status = 200;
            response.message = "Success";
            response.data = _dbJadwalSiswa.GetPelajaranbyname(nama);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

}
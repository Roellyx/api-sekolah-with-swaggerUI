using System.Data;
using MySql.Data.MySqlClient;

public class DbData
{
    private readonly string connectionString;
    private readonly MySqlConnection _connection;

    public DbData(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    public List<Hari> GetAllHari()
    {
        List<Hari> HariList = new List<Hari>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM hari_pelajaran";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Hari hari = new Hari
                        {
                            id_hari = Convert.ToInt32(reader["id_hari"].ToString()),
                            kode_hari = reader["kode_hari"].ToString(),
                            hari = reader["hari"].ToString()
                        };
                        HariList.Add(hari);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return HariList;
    }

    public List<Jam> GetAllJam()
    {
        List<Jam> JamList = new List<Jam>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM jam_pelajaran";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jam jam = new Jam
                        {
                            id_jam = Convert.ToInt32(reader["id_hari"].ToString()),
                            kode_jam = reader["kode_hari"].ToString(),
                            jam_mulai = reader["jam_mulai"].ToString(),
                            jam_akhir = reader["jam_akhir"].ToString()
                        };
                        JamList.Add(jam);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return JamList;
    }

    public List<Kelas> GetAllKelas()
    {
        List<Kelas> KelasList = new List<Kelas>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM kelas";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kelas kelas = new Kelas
                        {
                            id_kelas = Convert.ToInt32(reader["id_kelas"].ToString()),
                            kode_kelas = reader["kode_kelas"].ToString(),
                            kelas = reader["kelas"].ToString()
                        };
                        KelasList.Add(kelas);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return KelasList;
    }
}
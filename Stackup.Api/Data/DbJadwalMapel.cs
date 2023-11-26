using System.Data;
using MySql.Data.MySqlClient;

public class DbJadwalMapel
{
    private readonly string connectionString;
    private readonly MySqlConnection _connection;

    public DbJadwalMapel(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    public List<TampilJadwal> GetAllJadwal()
    {
        List<TampilJadwal> jadwalList = new List<TampilJadwal>();
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT pelajaran.mata_pelajaran, pelajaran.nama_guru, jam_pelajaran.jam_mulai, jam_pelajaran.jam_akhir, hari_pelajaran.hari, kelas.kelas FROM pelajaran JOIN jam_pelajaran ON pelajaran.kode_jam = jam_pelajaran.kode_jam JOIN hari_pelajaran ON pelajaran.kode_hari = hari_pelajaran.kode_hari JOIN kelas ON pelajaran.kode_kelas = kelas.kode_kelas;";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TampilJadwal jadwal = new TampilJadwal
                        {
                            mata_pelajaran = reader["mata_pelajaran"].ToString(),
                            nama_guru = reader["nama_guru"].ToString(),
                            jam_mulai = reader["jam_mulai"].ToString(),
                            jam_akhir = reader["jam_akhir"].ToString(),
                            hari = reader["hari"].ToString(),
                            kelas = reader["kelas"].ToString()
                        };
                        jadwalList.Add(jadwal);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return jadwalList;
    }

    public int CreateJadwal(Jadwal jadwal)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO pelajaran (kode_mapel, mata_pelajaran, nama_guru, kode_jam, kode_hari, kode_kelas) VALUES (@kode_mapel, @mata_pelajaran, @nama_guru, @kode_jam, @kode_hari, @kode_kelas)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@kode_mapel", jadwal.kode_mapel);
                command.Parameters.AddWithValue("@mata_pelajaran", jadwal.mata_pelajaran);
                command.Parameters.AddWithValue("@nama_guru", jadwal.nama_guru);
                command.Parameters.AddWithValue("@kode_jam", jadwal.kode_jam);
                command.Parameters.AddWithValue("@kode_hari", jadwal.kode_hari);
                command.Parameters.AddWithValue("@kode_kelas", jadwal.kode_kelas);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdateJadwal(int id, Jadwal jadwal)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "UPDATE pelajaran SET kode_mapel = @kode_mapel, mata_pelajaran = @mata_pelajaran, nama_guru = @nama_guru, kode_jam = @kode_jam, kode_hari = @kode_hari, kode_kelas = @kode_kelas WHERE id_mapel = @id_mapel";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@kode_mapel", jadwal.kode_mapel);
                command.Parameters.AddWithValue("@mata_pelajaran", jadwal.mata_pelajaran);
                command.Parameters.AddWithValue("@nama_guru", jadwal.nama_guru);
                command.Parameters.AddWithValue("@kode_jam", jadwal.kode_jam);
                command.Parameters.AddWithValue("@kode_hari", jadwal.kode_hari);
                command.Parameters.AddWithValue("@kode_kelas", jadwal.kode_kelas);
                command.Parameters.AddWithValue("@id_mapel", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeleteJadwal(int id)
    {
        using (MySqlConnection connection = _connection)
        {
            string query = "DELETE FROM pelajaran WHERE id_mapel = @id_mapel";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id_mapel", id);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

}
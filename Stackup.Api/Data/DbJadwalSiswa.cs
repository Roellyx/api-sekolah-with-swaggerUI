using System.Data;
using MySql.Data.MySqlClient;

public class DbJadwalSiswa
{
    private readonly string connectionString;
    private readonly MySqlConnection _connection;

    public DbJadwalSiswa(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }
    

    public List<Pelajaran> GetPelajaranbyname(string nama)
{
    List<Pelajaran> pelajaranList = new List<Pelajaran>();
    try
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string query = "SELECT siswa.nama_siswa AS nama_siswa, siswa.jurusan AS jurusan, kelas_siswa.kelas AS kelas_siswa, p1.mata_pelajaran AS mata_pelajaran, p1.nama_guru AS nama_guru, hari_pelajaran.hari AS hari, jam_pelajaran.jam_mulai AS jam_mulai, jam_pelajaran.jam_akhir AS jam_akhir, kelas_pelajaran.kelas AS kelas_pelajaran FROM siswa JOIN pelajaran AS p1 ON siswa.kode_mapel = p1.kode_mapel JOIN jam_pelajaran ON p1.kode_jam = jam_pelajaran.kode_jam JOIN hari_pelajaran ON p1.kode_hari = hari_pelajaran.kode_hari JOIN kelas AS kelas_pelajaran ON p1.kode_kelas = kelas_pelajaran.kode_kelas JOIN kelas AS kelas_siswa ON siswa.kode_kelas = kelas_siswa.kode_kelas WHERE siswa.nama_siswa LIKE @nama;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nama", "%" + nama + "%");
            connection.Open();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Pelajaran pelajaran = new Pelajaran
                    {
                        nama_siswa = reader["nama_siswa"].ToString(),
                        jurusan = reader["jurusan"].ToString(),
                        kelas_siswa = reader["kelas_siswa"].ToString(),
                        mata_pelajaran = reader["mata_pelajaran"].ToString(),
                        nama_guru = reader["nama_guru"].ToString(),
                        hari = reader["hari"].ToString(),
                        jam_mulai = reader["jam_mulai"].ToString(),
                        jam_akhir = reader["jam_akhir"].ToString(),
                        kelas_pelajaran = reader["kelas_pelajaran"].ToString(),

                    };
                    pelajaranList.Add(pelajaran);
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return pelajaranList;
}
}
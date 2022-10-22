using GestaoDocumento.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace GestaoDocumento.Data
{
    public class DocumentoRepository : ICrudOperation
    {
        static string connString = DbContext.ConnectionString;

        public void Add(Documento documento)
        {
            string sql = "INSERT INTO documento VALUES (@Codigo, @Titulo, @Revisao, @DataPlanejada, @Valor)";

            using (var conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", documento.Codigo);
                cmd.Parameters.AddWithValue("@Titulo", documento.Titulo);
                cmd.Parameters.AddWithValue("@Revisao", documento.Revisao);
                cmd.Parameters.AddWithValue("@DataPlanejada", documento.DataPlanejada);
                cmd.Parameters.AddWithValue("@Valor", documento.Valor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE documento WHERE Id=@Id";

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Documento> Get()
        {
            string sql = "SELECT * FROM documento ORDER BY Id DESC";
            List<Documento> documentos = new List<Documento>();

            using (var conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        Documento documento = new Documento();

                        documento.Id = (int)reader["Id"];
                        documento.Codigo = reader["Codigo"].ToString();
                        documento.Titulo = reader["Titulo"].ToString();
                        documento.Revisao = reader["Revisao"].ToString()[0];
                        documento.DataPlanejada = (DateTime)reader["DataPlanejada"];
                        documento.Valor = (Decimal)reader["Valor"];
                        documentos.Add(documento);
                    }
                }

                return documentos;
            }
        }

        public Documento Get(int id)
        {
            string sql = "SELECT * FROM documento WHERE Id=@Id";
            Documento documento = null;

            using (var conn = new MySqlConnection(connString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        documento.Id = (int)reader["Id"];
                        documento.Codigo = reader["Codigo"].ToString();
                        documento.Titulo = reader["Titulo"].ToString();
                        documento.Revisao = reader["Revisao"].ToString()[0];
                        documento.DataPlanejada = (DateTime)reader["DataPlanejada"];
                        documento.Valor = (Decimal)reader["Valor"];
                    }
                }

                return documento;
            }
        }

        public void Update(Documento documento)
        {
            string sql = "UPDATE documento SET Codigo=@Codigo, Titulo=@Titulo, Revisao=@Revisao, DataPlanejada=@DataPlanejada, Valor=@Valor)";

            using (var conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", documento.Codigo);
                cmd.Parameters.AddWithValue("@Titulo", documento.Titulo);
                cmd.Parameters.AddWithValue("@Revisao", documento.Revisao);
                cmd.Parameters.AddWithValue("@DataPlanejada", documento.DataPlanejada);
                cmd.Parameters.AddWithValue("@Valor", documento.Valor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

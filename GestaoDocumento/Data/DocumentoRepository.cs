using GestaoDocumento.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace GestaoDocumento.Data
{
    public class DocumentoRepository : ICrudOperation
    {
        static string connString = DbContext.ConnectionString;

        public void Create(Documento documento)
        {
            string sql = "INSERT INTO documento VALUES (@Codigo, @Titulo, @Revisao, @DataPlanejada, @Valor)";

            using (var conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", documento.Codigo);
                cmd.Parameters.AddWithValue("@Titulo", documento.Titulo);
                cmd.Parameters.AddWithValue("@Revisao", documento.Revisao.ToString().Replace("_", ""));
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

        public List<Documento> Read()
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
                        Enum.TryParse(reader["Revisao"].ToString(), out Documento.RevisaoEnum revisao);
                        documento.Revisao = revisao;
                        documento.DataPlanejada = (DateTime)reader["DataPlanejada"];
                        documento.Valor = (Decimal)reader["Valor"];
                        documentos.Add(documento);
                    }
                }

                return documentos;
            }
        }

        public Documento Read(int id)
        {
            string sql = "SELECT * FROM documento WHERE Id=@Id";

            using (var conn = new MySqlConnection(connString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows && reader.Read())
                    {
                        Documento documento = new Documento();

                        documento.Id = (int)reader["Id"];
                        documento.Codigo = reader["Codigo"].ToString();
                        documento.Titulo = reader["Titulo"].ToString();
                        Enum.TryParse(reader["Revisao"].ToString(), out Documento.RevisaoEnum revisao);
                        documento.Revisao = revisao;
                        documento.DataPlanejada = (DateTime)reader["DataPlanejada"];
                        documento.Valor = (Decimal)reader["Valor"];

                        return documento;
                    }
                }
            }

            return null;
        }

        public void Update(Documento documento)
        {
            string sql = @"
                UPDATE documento SET
                    Codigo=@Codigo,
                    Titulo=@Titulo,
                    Revisao=@Revisao,
                    DataPlanejada=@DataPlanejada,
                    Valor=@Valor
                WHERE Id=@Id";

            using (var conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", documento.Id);
                cmd.Parameters.AddWithValue("@Codigo", documento.Codigo);
                cmd.Parameters.AddWithValue("@Titulo", documento.Titulo);
                cmd.Parameters.AddWithValue("@Revisao", documento.Revisao.ToString().Replace("_", ""));
                cmd.Parameters.AddWithValue("@DataPlanejada", documento.DataPlanejada);
                cmd.Parameters.AddWithValue("@Valor", documento.Valor);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

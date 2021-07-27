using System;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    //Modelo Automóvel com todos os comandos de SQL
    public class Automovel
    {
        #region Métodos

        //Método Query para guardar carro, neste caso faz o UPDATE na BD caso já exista, se não faz o INSERT de novo Carro

        public static bool GuardarAutomovel(
                   int idAutomovel,
                   int idUtilizador,
                   int idMarca,
                   int idModelo,
                   int ano,
                   int kms,
                   string condicao,
                   int portas,
                   string combustivel,
                   float preco,
                   string mediaURL,
                   DateTime dataEntrada,
                   DateTime? dataVenda,
                   out string mensagemErro,
                   out string caminhoErro)
        {
            bool ok = false;
            mensagemErro = string.Empty;
            caminhoErro = string.Empty;

            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Guardar_Automovel", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("ID", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idAutomovel;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("IDUtilizador", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idUtilizador;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("IDMarca", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idMarca;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("IDModelo", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idModelo;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Ano", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = ano;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("KMS", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = kms;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Condicao", System.Data.SqlDbType.NVarChar, 15);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = condicao;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Portas", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = portas;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Combustivel", System.Data.SqlDbType.NVarChar, 20);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = combustivel;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Preco", System.Data.SqlDbType.Float);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = preco;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("MediaURL", System.Data.SqlDbType.NVarChar, 225);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = mediaURL;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("DataEntrada", System.Data.SqlDbType.Date);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = dataEntrada;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("DataVenda", System.Data.SqlDbType.Date);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = dataVenda;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteNonQuery();

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();

                ok = true;
            }
            catch (SqlException sqlEx)
            {
                mensagemErro = "Erro do SQL!";
                caminhoErro = sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                caminhoErro = ex.StackTrace;
            }
            finally
            {

            }

            return ok;
        }


        //Método Query Carregar todas as informações para 1 carro

        public static bool ObterAutomovel(
                   int idAutomovel,
                   int idUtilizador,
                   int idMarca,
                   int idModelo,
                   string descricaoMarca,
                   string descricaoModelo,
                   int ano,
                   int kms,
                   string condicao,
                   int portas,
                   string combustivel,
                   float preco,
                   string mediaURL,
                   DateTime dataEntrada,
                   DateTime dataVenda,
                   out string mensagemErro,
                   out string caminhoErro)
        {
            bool ok = false;
            mensagemErro = string.Empty;
            caminhoErro = string.Empty;

            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Automovel", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("ID", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idAutomovel;

                sqlCommand.Parameters.Add(sqlParameter);

                SqlDataReader sqlDataReader =
                    sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        idUtilizador = sqlDataReader.GetInt16(1);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        idMarca = sqlDataReader.GetInt16(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        idModelo = sqlDataReader.GetInt16(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        descricaoMarca = sqlDataReader.GetString(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        descricaoModelo = sqlDataReader.GetString(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        ano = sqlDataReader.GetInt16(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        kms = sqlDataReader.GetInt16(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        condicao = sqlDataReader.GetString(9);
                    }
                    if (!sqlDataReader.IsDBNull(10))
                    {
                        portas = sqlDataReader.GetInt16(10);
                    }
                    if (!sqlDataReader.IsDBNull(11))
                    {
                        combustivel = sqlDataReader.GetString(11);
                    }
                    if (!sqlDataReader.IsDBNull(12))
                    {
                        preco = sqlDataReader.GetFloat(12);
                    }
                    if (!sqlDataReader.IsDBNull(13))
                    {
                        mediaURL = sqlDataReader.GetString(13);
                    }
                    if (!sqlDataReader.IsDBNull(14))
                    {
                        dataEntrada = sqlDataReader.GetDateTime(14);
                    }
                    if (!sqlDataReader.IsDBNull(15))
                    {
                        dataVenda = sqlDataReader.GetDateTime(15);
                    }

                    ok = true;
                }

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();

                ok = true;
            }
            catch (SqlException sqlEx)
            {
                mensagemErro = "Erro do SQL!";
                caminhoErro = sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                caminhoErro = ex.StackTrace;
            }
            finally
            {

            }
            return ok;
        }



        //Método Query Obter todos os carros
        public static DataTable ObterAutomoveis()
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Automoveis", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
            }
            return dataTable;
        }



        //Método Query Eliminar 1 carro 

        public static bool EliminarAutomovel(int idAutomovel,
                   out string mensagemErro,
                   out string caminhoErro)
        {
            bool ok = false;
            mensagemErro = string.Empty;
            caminhoErro = string.Empty;

            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Eliminar_Automovel", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("ID", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idAutomovel;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteNonQuery();

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();

                ok = true;
            }
            catch (SqlException sqlEx)
            {
                mensagemErro = "SQL ERROR!";
                caminhoErro = sqlEx.StackTrace;
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                caminhoErro = ex.StackTrace;
            }
            finally
            {

            }

            return ok;
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class Marca
    {
        //Classe Marca

        //Obter apenas 1 marca dando o id respectivo
        public static bool ObterMarca(
           int marcaID,
           string marcaDescricao,
           out string mensagemErro,
           out string caminhoErro)
        {
            bool ok = false;
            mensagemErro = string.Empty;
            caminhoErro = string.Empty;

            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Marca", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("ID", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = marcaID;

                sqlCommand.Parameters.Add(sqlParameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        marcaID = sqlDataReader.GetInt16(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        marcaDescricao = sqlDataReader.GetString(2);
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


        //método carregar todas as marcas usando o procedure 'Obter_Marcas'

        public static DataTable ObterMarcas()
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Marcas", sqlConnection);
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
    }
}

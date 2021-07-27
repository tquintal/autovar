using System;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class Modelo
    {

        //Classe Marca

        //Obter apenas 1 modelo dando o id respectivo
        public static bool ObterModelo(
           int modeloID,
           int marcaID,
           string modeloDescricao,
           out string mensagemErro,
           out string caminhoErro)
        {
            bool ok = false;
            mensagemErro = string.Empty;
            caminhoErro = string.Empty;

            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Modelo", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("ID", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = modeloID;

                sqlCommand.Parameters.Add(sqlParameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        modeloID = sqlDataReader.GetInt16(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        marcaID = sqlDataReader.GetInt16(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        modeloDescricao = sqlDataReader.GetString(3);
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

        //método carregar todas os modelos usando o procedure 'Obter_Modelos'

        public static DataTable ObterModelos()
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = ConnectionString.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Obter_Modelos", sqlConnection);
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

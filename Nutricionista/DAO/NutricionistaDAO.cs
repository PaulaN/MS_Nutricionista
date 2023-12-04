using AcompanhamentoFisico.Model;
using System.Data.SqlClient;
using System.Data;
using AcompanhamentoFisico.DTO;
using AutoMapper;

namespace AcompanhamentoFisico.DAO
{
	public class NutricionistaDAO
	{
        String conexao = @"Server=DESKTOP-BJNTUCI\MSSQLSERVER01;Database=Cliente;Trusted_Connection=True";

        #region Nutricionista



        public NutricionistaDTO retornaNutricionista(String CRN)
        {
            NutricionistaDTO nutricionistaDTO = new NutricionistaDTO();
            Nutricionista nutricionista = new Nutricionista();

            string sql = "select id_nutricionista,nome,CRN from dbo.Nutricionista  where CRN=" + CRN;

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nutricionista.id = Convert.ToInt32(reader[0].ToString());
                    nutricionista.nome = reader[1].ToString();
                    nutricionista.CRN = reader[2].ToString();

                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Nutricionista, NutricionistaDTO>();
                    });
                    var mapper = configuration.CreateMapper();
                    nutricionistaDTO = mapper.Map<NutricionistaDTO>(nutricionista);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return nutricionistaDTO;
        }

        public int InsereNutricionista(NutricionistaDTO nutricionistaDTO)
		{
            
			string sql = "INSERT INTO dbo.Nutricionista (nome,CRN) VALUES (" + "'" + nutricionistaDTO.nome + "'" + "," + "'" + nutricionistaDTO.CRN + "'" + ")";
			
			SqlConnection con = new SqlConnection(conexao);
			SqlCommand cmd = new SqlCommand(sql, con);
			cmd.CommandType = CommandType.Text;
			SqlDataReader reader;
			con.Open();
			int retorno = cmd.ExecuteNonQuery();

			return retorno;
		}


        public int alteraNutricionista(NutricionistaDTO nutricionistaDTO)
        {

          
            string sql = "UPDATE dbo.Nutricionista SET  nome=" + "'" + nutricionistaDTO.nome + "'" + "   where CRN=" + "'" + nutricionistaDTO.CRN + "'";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int retorno = cmd.ExecuteNonQuery();

            return retorno;
        }

        public int deletaNutricionista(String CRN)
        {
            String retorno = "";
            string sql = "delete from dbo.Nutricionista where CRN = " + CRN;

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            int i = cmd.ExecuteNonQuery();
            return i;

        }

        #endregion

      

    }
}

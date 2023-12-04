using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.BLL
{
	public class NutricionistaBLL
	{
		NutricionistaDAO dao = new NutricionistaDAO();
        int retornoProfissionais = 0;


        #region Nutricionista
        public NutricionistaDTO retornaNutricionista(String CRN)
        {

            NutricionistaDTO nutricionistaDTO = dao.retornaNutricionista(CRN);


            return nutricionistaDTO;
        }

        public String insereNutricionista(NutricionistaDTO nutricionistaDTO)
		{
            retornoProfissionais = 0;
            retornoProfissionais = dao.InsereNutricionista(nutricionistaDTO);


			return retornoProfissionais == 1 ? "Cadastro realizado com sucesso" : "Não foi possível cadastrar nutricionista";
		}

        public String alteraNutricionista(NutricionistaDTO nutricionistaDTO)
        {
            retornoProfissionais = 0;

            retornoProfissionais = dao.alteraNutricionista(nutricionistaDTO);

            return retornoProfissionais == 1 ? "Alteração realizada com sucesso" : "Não foi possível alterar nutricionista";
        }
        public String deletaNutricionista(String CRN)
        {
            retornoProfissionais = 0;


            if (CRN != null)
            {
                retornoProfissionais = dao.deletaNutricionista(CRN);
            }

            return retornoProfissionais == 1 ? "Dados deletados com sucesso" : "Não foi possível deletar nutricionista";
        }

     
        #endregion

       

    }
}

using AcompanhamentoFisico.BLL;
using AcompanhamentoFisico.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcompanhamentoFisico.Controllers
{
	[Route("api/Profissionais")]
	[ApiController]
	public class NutricionistaController : ControllerBase
	{
		NutricionistaBLL bll = new NutricionistaBLL();

        #region Nutricionista
        [HttpGet("{CRN}")]
        public NutricionistaDTO BuscaPorCRN(String CRN)
        {

            
            NutricionistaDTO nutricionistaDTO = bll.retornaNutricionista(CRN);


            return nutricionistaDTO;
        }


        [HttpPost]
		public String Post(NutricionistaDTO nutricionistaDTO)
		{
		  String retorno=bll.insereNutricionista(nutricionistaDTO);

			return retorno;
		}


        [HttpPut]
        public String Put(NutricionistaDTO nutricionistaDTO)
        {
            String retorno = bll.alteraNutricionista(nutricionistaDTO);

            return retorno;
        }


        [HttpDelete("{CRN}")]
        public String Delete(String CRN)
        {
            String retorno = bll.deletaNutricionista(CRN);

            return retorno;
        }

        #endregion
    }
}

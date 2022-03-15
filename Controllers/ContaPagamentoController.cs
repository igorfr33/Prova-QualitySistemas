using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaPagamentoController : ControllerQuality
    {
        [Route(""), HttpPost]
        public async Task <IEnumerable<dynamic>> GetResults()
        {
            try
            {
                var body = await this.GetBody<Data.ContaPagamento>();

                 if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else
                {
                }

                 Data.ContaPagamento contaPagamento = new Data.ContaPagamento();

                contaPagamento.idEmpresa = body.idEmpresa;
                contaPagamento.descricao = body.descricao;

                contaPagamento = (Data.ContaPagamento) sr.consultar(contaPagamento);

                return (IEnumerable<dynamic>)UtilsGestao.UtilsApi.Retorno(contaPagamento).ToArray().Take(10);

            }
            catch (Exception ex)
            {
                return (IEnumerable<dynamic>)BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }

        [Route(""), HttpGet]
        public async Task <ActionResult<dynamic>> GetConta()
        {
            try
            {
                var body = await this.GetBody<Data.ContaPagamento>();

                 if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else
                {
                }

                 Data.ContaPagamento contaPagamento = new Data.ContaPagamento();

                contaPagamento.idContaPagamento = body.idContaPagamento;

                contaPagamento = (Data.ContaPagamento) sr.consultar(contaPagamento);

                return UtilsGestao.UtilsApi.Retorno(contaPagamento);

            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }     
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Models;
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
        [Route("/GetResults"), HttpPost]
        public async Task <ActionResult<dynamic>> GetResults()
        {
            try 
                {
            var body = await this.GetBody<Data.ContaPagamento>();

            if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else { }

            Data.ContaPagamento contaPagamento = new Data.ContaPagamento();

            contaPagamento.idEmpresa = body.idEmpresa;
            contaPagamento.descricao = body.descricao;

            List<Utils.NameValue> _params = new List<Utils.NameValue>();
            _params.Add(new Utils.NameValue { name = "Order", value = "idEmpresa" });

            List<Data.Base> results = Utils.Utils.listaDados(this.idEmpresa, contaPagamento, this.maxRowsPerPage, _params);

            var obj = new
                {
                    totalRows = Utils.Utils.getCount(idEmpresa, contaPagamento, _params),
                    maxRowsPerPage,
                    startRowIndex,
                    results,

                    grid = GenerateGrid ? new UtilsApi.Grid().FillFormComponentFields(contaPagamento.GetType(), false) : new GridModel { }
                };
            return UtilsGestao.UtilsApi.Retorno(obj);
            }

            catch(Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }

        [Route("/api/contaPagamento?idContaPagamento"), HttpGet]
        public async Task <ActionResult<dynamic>> GetConta()
        {
            try
            {
                

                Data.ContaPagamento contaPagamento = new Data.ContaPagamento
                {
                 idContaPagamento = this.GetQueryString<int>("idContaPagamento")
                };

                contaPagamento = (Data.ContaPagamento)Utils.Utils.sr(0).consultar(contaPagamento);
                
                List<Utils.NameValue> _params = new List<Utils.NameValue>();

                return UtilsGestao.UtilsApi.Retorno(contaPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }     
    }
}


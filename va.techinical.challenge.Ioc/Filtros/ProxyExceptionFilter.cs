using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using va.technical.challenge.domain.Modelos;

namespace va.technical.challenge.api.Filtros
{
    public class ProxyExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => 0;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.ExceptionHandled = true;
                var erros = new List<Erro>();
                var modelStateErros = context.ModelState.Values.SelectMany(e => e.Errors);
                foreach (var item in modelStateErros)
                    erros.Add(new Erro(Guid.NewGuid().ToString(), item.ErrorMessage));

                BaseResponse baseResponse = new BaseResponse
                {
                    Erros = erros,
                    Success = false
                };

                context.Result = new ObjectResult(baseResponse)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = baseResponse
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = new List<Erro>();
                var modelStateErros = context.ModelState.Values.SelectMany(e => e.Errors);
                foreach (var item in modelStateErros)
                    erros.Add(new Erro(Guid.NewGuid().ToString(), item.ErrorMessage));

                BaseResponse baseResponse = new BaseResponse
                {
                    Erros = erros,
                    Success = false
                };

                context.Result = new ObjectResult(baseResponse)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = baseResponse
                };
            }
        }
    }
}
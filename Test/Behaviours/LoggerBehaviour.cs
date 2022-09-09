using MediatR;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System;
using Test.Infrastructure.Context;
using Test.Infrastructure.DataModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Test.Behaviours
{
    public class LoggerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly DatabaseContext _memory;
        private Log _logEntity;

        public LoggerBehaviour(DatabaseContext memory)
        {
            _memory = memory;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await AppendRequestToLog(request);
            var response = await next();
            await AppendResponsetToLog(response);
            return response;
        }

        private async Task AppendRequestToLog(TRequest request)
        {
            _logEntity = new Log()
            {
                TypeName = request.GetType().Name,
                Request = Newtonsoft.Json.JsonConvert.SerializeObject(request),
            };
        }

        private async Task AppendResponsetToLog(TResponse response)
        {
            _logEntity.Response = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            await _memory.Set<Log>().AddAsync(_logEntity);
            await _memory.SaveChangesAsync();
        }
    }
}

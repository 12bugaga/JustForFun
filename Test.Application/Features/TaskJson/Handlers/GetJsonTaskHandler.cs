using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Test.Application.Features.TaskJson.Interfaces;
using Test.Application.Features.TaskJson.Request;
using Test.Application.Features.TaskJson.Response;
using MediatR;
using System.Linq;

namespace Test.Application.Features.TaskJson.Handlers
{
    public class GetJsonTaskHandler : IRequestHandler<GetJsonTaskRequest, GetJsonTaskResponse>
    {
        private readonly IJsonTaskRepository _repo;

        public GetJsonTaskHandler(IJsonTaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<GetJsonTaskResponse> Handle(GetJsonTaskRequest request, CancellationToken cancellationToken)
        {
            var response = new GetJsonTaskResponse
            {
                JsonTasks = (await _repo.GetJsonTasks(request)).ToList(),
            };

            return response;
        }
    }
}

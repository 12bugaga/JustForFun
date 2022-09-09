using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Test.Application.Features.TaskJson.Interfaces;
using Test.Application.Features.TaskJson.Request;
using Test.Application.Features.TaskJson.Response;
using MediatR;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Test.Application.Features.TaskJson.DTO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Linq;

namespace Test.Application.Features.TaskJson.Handlers
{
    public class JsonTaskAddHandler : IRequestHandler<AddJsonTaskRequest, AddJsonTaskResponse>
    {
        private readonly IJsonTaskRepository _repo;

        public JsonTaskAddHandler(IJsonTaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<AddJsonTaskResponse> Handle(AddJsonTaskRequest request, CancellationToken cancellationToken)
        {
            var replaceChar = new char[] { '[', ']', '{', '}'};
            request.JsonValues = String.Concat("{", replaceChar.Aggregate(request.JsonValues, (c1, c2) => c1.Replace(c2, ' ').Replace(" ", "")), "}");
            var pairs = new Dictionary<int, string>();
            try 
            {
                pairs = JsonConvert.DeserializeObject<Dictionary<int, string>>(request.JsonValues);
            }
            catch
            {
                return new AddJsonTaskResponse
                {
                    IsSuccess = false,
                    Message = "Check input data",
                };
            }

            var jsonTasksDTO = pairs.OrderBy(a => a.Key)
                                    .Select((pair, index) => new JsonTaskDTO
                                    {
                                        Id = index,
                                        Code = pair.Key,
                                        Value = pair.Value,
                                    }).ToList();

            await _repo.ClearTable();
            await _repo.SaveChangeAsync();

            await _repo.AddRangeAsync(jsonTasksDTO.AsEnumerable());
            await _repo.SaveChangeAsync();

            return new AddJsonTaskResponse
            {
                IsSuccess = true,
            };
        }
    }
}

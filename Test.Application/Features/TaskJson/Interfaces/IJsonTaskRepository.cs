using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Features.TaskJson.DTO;
using Test.Application.Features.TaskJson.Request;

namespace Test.Application.Features.TaskJson.Interfaces
{
    public interface IJsonTaskRepository
    {
        public Task AddRangeAsync(IEnumerable<JsonTaskDTO> jsonTasks);
        public Task ClearTable();
        public Task SaveChangeAsync();
        public Task<IEnumerable<JsonTaskDTO>> GetJsonTasks(GetJsonTaskRequest request);
    }
}

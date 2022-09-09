using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Features.TaskJson.DTO;
using Test.Application.Features.TaskJson.Interfaces;
using Test.Application.Features.TaskJson.Request;
using Test.Infrastructure.Context;
using Test.Infrastructure.DataModels;

namespace Test.Infrastructure.Repository
{
    public class JsonTaskRepository : IJsonTaskRepository
    {
        private readonly DatabaseContext _memory;
        private readonly IMapper _mapper;

        public JsonTaskRepository(DatabaseContext memory, IMapper mapper)
        {
            _memory = memory;
            _mapper = mapper;
        }

        public async Task AddRangeAsync(IEnumerable<JsonTaskDTO> jsonTasks)
            => await _memory.Set<JsonTask>().AddRangeAsync(_mapper.Map<IEnumerable<JsonTask>>(jsonTasks));

        public async Task ClearTable()
        {
            var allFields = _memory.Set<JsonTask>().AsEnumerable();
            _memory.Set<JsonTask>().RemoveRange(allFields);
        }

        public async Task SaveChangeAsync()
            => await _memory.SaveChangesAsync();

        public async Task<IEnumerable<JsonTaskDTO>> GetJsonTasks(GetJsonTaskRequest request)
            => _memory.Set<JsonTask>().Where(a => (request.IsEmptyValue ? String.IsNullOrEmpty(a.Value) : true)
                                             && (request.MinCode != 0 ? a.Code >= request.MinCode : true)
                                             && (request.MaxCode != 0 ? a.Code <= request.MaxCode : true))
                                      .ProjectTo<JsonTaskDTO>(_mapper.ConfigurationProvider)
                                      .ToList();
    }
}

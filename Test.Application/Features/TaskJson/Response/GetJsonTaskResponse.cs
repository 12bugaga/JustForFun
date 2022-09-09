using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Application.Features.TaskJson.DTO;

namespace Test.Application.Features.TaskJson.Response
{
    public class GetJsonTaskResponse
    {
        public List<JsonTaskDTO> JsonTasks { get; set; }
    }
}

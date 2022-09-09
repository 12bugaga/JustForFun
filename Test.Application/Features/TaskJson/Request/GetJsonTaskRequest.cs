using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Application.Features.TaskJson.Response;

namespace Test.Application.Features.TaskJson.Request
{
    public class GetJsonTaskRequest : IRequest<GetJsonTaskResponse>
    {
        public int MinCode { get; set; }
        public int MaxCode { get; set; }
        public bool IsEmptyValue { get; set; }
    }
}

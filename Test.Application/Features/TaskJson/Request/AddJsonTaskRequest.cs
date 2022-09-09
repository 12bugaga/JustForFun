using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Test.Application.Features.TaskJson.Response;

namespace Test.Application.Features.TaskJson.Request
{
    public class AddJsonTaskRequest : IRequest<AddJsonTaskResponse>
    {
        public string JsonValues { get; set; }
    }
}

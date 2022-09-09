using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Application.Features.TaskJson.DTO
{
    public class JsonTaskDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Value { get; set; }
    }
}

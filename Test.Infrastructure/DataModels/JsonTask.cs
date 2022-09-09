using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Infrastructure.DataModels
{
    public class JsonTask
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Value { get; set; }
    }
}

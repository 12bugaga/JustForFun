using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Infrastructure.DataModels.Common
{
    public class Log
    {
        [Key]
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

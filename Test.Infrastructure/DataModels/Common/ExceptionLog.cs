using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Infrastructure.DataModels.Common
{
    public class ExceptionLog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

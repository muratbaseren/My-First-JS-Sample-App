using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstJSApp.Models
{
    public class JsonResultObject
    {
        public bool HasError { get; set; }
        public int? NewTaskId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Models.Response
{
    public class ErrorResponse : Response
    {
        public string Error { get; set; }
        public string Description { get; set; }
    }
}

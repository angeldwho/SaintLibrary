
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.BLL.Models.Request.CreateRequest;

namespace MyLibrary.BLL.Models.Request
{
    public class CategoryRequestModel : CategoryCreateRequestModel
    {
        public int ID { get; set; }

    }
}

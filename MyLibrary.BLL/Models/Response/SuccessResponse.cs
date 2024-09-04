using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Models.Response
{
    public class SuccessResponse<T> : Response where T : class
    {
        public IList<T> results {  get; set; }
        public T result { get; set; }
        public SuccessResponse(IList<T> results)
        {
            this.results = results;
        }
        public SuccessResponse(T result)
        {
            this.result = result;
        }
    }
}

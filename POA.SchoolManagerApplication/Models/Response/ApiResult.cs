using System;
using System.Collections.Generic;

namespace POA.SchoolManagerApplication.Models
{
    public class ApiResult<T>
    {
        public bool Include_Total { get; set; }
        public Guid Resource_Id { get; set; }
        public IEnumerable<T> Records { get; set; }
    }
}

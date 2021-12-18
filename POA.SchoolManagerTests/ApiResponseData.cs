using System;
using System.Collections.Generic;
using System.Text;

namespace POA.SchoolManagerTests
{
    public class ApiResponseData
    {
        public string Help { get; set; }
        public bool Success { get; set; }
        public ApiResult Result { get; set; }
    }

    public class ApiResult
    {
        public bool Include_Total { get; set; }
        public Guid Resource_Id { get; set; }
        public IEnumerable<School> Records { get; set; }
    }

    public class School
    {
        public string Dep_Admionistrativa { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Abr_Nome { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitute { get; set; }
        public string Email { get; set; }
        public string Url_WebSite { get; set; }
        public string Telefone { get; set; }
    }
}

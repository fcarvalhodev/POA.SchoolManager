using Newtonsoft.Json;

namespace POA.SchoolManagerApplication.Models
{
    public class SchoolModel
    {
        [JsonPropertyAttribute("dep_administrativa")]
        public string Dep_administrativa { get; set; }

        [JsonPropertyAttribute("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyAttribute("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyAttribute("nome")]
        public string Nome { get; set; }

        [JsonPropertyAttribute("abr_nome")]
        public string Abr_Nome { get; set; }

        [JsonPropertyAttribute("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyAttribute("numero")]
        public int Numero { get; set; }

        [JsonPropertyAttribute("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyAttribute("cep")]
        public string Cep { get; set; }

        [JsonPropertyAttribute("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyAttribute("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyAttribute("email")]
        public string Email { get; set; }

        [JsonPropertyAttribute("url_website")]
        public string Url_WebSite { get; set; }

        [JsonPropertyAttribute("telefone")]
        public string Telefone { get; set; }
    }
}

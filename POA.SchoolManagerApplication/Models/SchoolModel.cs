using System.Text.Json.Serialization;

namespace POA.SchoolManagerApplication.Models
{
    public class SchoolModel
    {
        [JsonPropertyName("dep_administrativa")]
        public string Dep_Administrativa { get; set; }
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("abr_nome")]
        public string Abr_Nome { get; set; }
        [JsonPropertyName("numero")]
        public int Numero { get; set; }
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitute { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("url_webSite")]
        public string Url_WebSite { get; set; }
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }
    }
}

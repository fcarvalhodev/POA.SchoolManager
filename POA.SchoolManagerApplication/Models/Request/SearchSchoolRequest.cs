using Flunt.Notifications;
using System;

namespace POA.SchoolManagerApplication.Models
{
    public class SearchSchoolRequest : Notifiable<Notification>
    {
        public SearchSchoolRequest(string cep, string logradouro, string bairro)
        {
            this.Cep = cep;
            ValidateCep(Cep);
            this.Logradouro = logradouro;
            ValidateLogradouro(logradouro);
            this.Bairro = bairro;
            ValidateBairro(logradouro);
        }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        private void ValidateBairro(string bairro)
        {
            if (bairro.Length > 255)
                AddNotification("Bairro", "The field must have less than 255 characters.");

        }

        private void ValidateLogradouro(string logradouro)
        {
            if (logradouro.Length > 255)
                AddNotification("Logradouro", "The field must have less than 255 characters.");
        }
        
        private void ValidateCep(string cep)
        {
            if (cep.Length != 8)
                AddNotification("Cep", "The field must have exactly 10 characters.");
        }
    }
}

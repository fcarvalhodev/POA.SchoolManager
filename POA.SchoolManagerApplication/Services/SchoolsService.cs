using POA.SchoolManagerApplication.Models;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace POA.SchoolManagerApplication.Services
{
    public class SchoolsService : ISchoolsService
    {
        private RestClient _client;
        private CancellationTokenSource _cancellationTokenSource;

        public SchoolsService()
        {
            Uri url = new Uri("https://dadosabertos.poa.br/api/3/action", UriKind.Absolute);
            _client = new RestClient(url);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<ApiResponse<SchoolModel>> GetAll()
        {
            try
            {
                string query = $"/datastore_search_sql?sql=SELECT EMAIL, URL_WEBSITE, DEP_ADMINISTRATIVA, TELEFONE, NOME, ABR_NOME, LOGRADOURO, NUMERO, BAIRRO, CEP, LATITUDE, LONGITUDE, TIPO " +
                          $"from \"5579bc8e-1e47-47ef-a06e-9f08da28dec8\" " +
                          $"WHERE CODIGO IS NOT NULL ";

                var requestAll = new RestRequest(query, DataFormat.Json);
                ApiResponse<SchoolModel> response = await _client.GetAsync<ApiResponse<SchoolModel>>(requestAll, _cancellationTokenSource.Token);

                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<SchoolModel> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ApiResponse<SchoolModel>> GetByQuery(SearchSchoolRequest request)
        {
            try
            {
                if (request.IsValid)
                {
                    string query = $"/datastore_search_sql?sql=SELECT EMAIL, URL_WEBSITE, DEP_ADMINISTRATIVA, TELEFONE, NOME, ABR_NOME, LOGRADOURO, NUMERO, BAIRRO, CEP, LATITUDE, LONGITUDE, TIPO " +
                                   $"from \"5579bc8e-1e47-47ef-a06e-9f08da28dec8\" " +
                                   $"WHERE CODIGO IS NOT NULL ";

                    if (!string.IsNullOrEmpty(request.Logradouro))
                        query = query + $" AND LOGRADOURO LIKE '{request.Logradouro}%'";
                    if (!string.IsNullOrEmpty(request.Bairro))
                        query = query + $" AND BAIRRO LIKE '{request.Bairro}%'";
                    if (!string.IsNullOrEmpty(request.Cep))
                        query = query + $" AND CEP = {request.Cep}";

                    var requestByQry = new RestRequest(query, DataFormat.Json);
                    ApiResponse<SchoolModel> response = await _client.GetAsync<ApiResponse<SchoolModel>>(requestByQry, _cancellationTokenSource.Token);

                    return response;
                }
                else
                {
                    string notificacoes = string.Join(" ", request.Notifications);
                    return new ApiResponse<SchoolModel> { Success = false, Message = notificacoes };
                }

            }
            catch (Exception ex)
            {
              
                return new ApiResponse<SchoolModel> { Success = false, Message = ex.Message };
            }
        }
    }
}

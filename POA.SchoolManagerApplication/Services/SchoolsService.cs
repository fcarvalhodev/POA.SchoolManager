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
                string query = "/datastore_search?resource_id=5579bc8e-1e47-47ef-a06e-9f08da28dec8&limit=10";

                var request = new RestRequest(query, DataFormat.Json);
                ApiResponse<SchoolModel> response = await _client.GetAsync<ApiResponse<SchoolModel>>(request, _cancellationTokenSource.Token);

                return response;

            }catch(Exception ex)
            {
                return new ApiResponse<SchoolModel> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ApiResponse<SchoolModel>> GetByQuery(SearchSchoolRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}

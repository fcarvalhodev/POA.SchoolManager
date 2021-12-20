using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POA.SchoolManagerTests
{
    [TestClass]
    public class ApiUniTest
    {
        private RestClient _client;
        private CancellationTokenSource _cancellationTokenSource;

        [TestInitialize()]
        public void Startup()
        {
            Uri url = new Uri("https://dadosabertos.poa.br/api/3/action", UriKind.Absolute);
            _client = new RestClient(url);
            _client.Timeout = 10000;
            _cancellationTokenSource = new CancellationTokenSource();
        }


        [TestMethod]
        public async Task GivenANewEndPoint_CallMustWork_WhenWeCallTheUrlAsync()
        {
            try
            {
                //Arrange
                string query = "/datastore_search?resource_id=5579bc8e-1e47-47ef-a06e-9f08da28dec8&limit=5";

                //Act
                var request = new RestRequest(query, DataFormat.Json);
                ApiResponseData response = await _client.GetAsync<ApiResponseData>(request, _cancellationTokenSource.Token);

                Assert.IsNotNull(response);
                Assert.IsTrue(response.Success);
                Assert.IsTrue(response.Result.Records.Count() == 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.IsFalse(true);
            }
        }

        [TestMethod]
        public async Task GivenAddressSearch_MustSearchByAddress_WhenValueNotNullTheUrlAsync()
        {
            try
            {
                //Arrange
                string value = "AZENHA";
                string query = $"/datastore_search?resource_id=5579bc8e-1e47-47ef-a06e-9f08da28dec8&q={value}";

                //Act
                var request = new RestRequest(query, DataFormat.Json);
                ApiResponseData response = await _client.GetAsync<ApiResponseData>(request, _cancellationTokenSource.Token);

                Assert.IsNotNull(response);
                Assert.IsTrue(response.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.IsFalse(true);
            }
        }

    }
}

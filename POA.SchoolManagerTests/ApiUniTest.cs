using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace POA.SchoolManagerTests
{
    [TestClass]
    public class ApiUniTest
    {
        RestClient _client;

        [TestInitialize()]
        public void Startup()
        {
            _client = new RestClient("https://dadosabertos.poa.br/api/3/action");
        }


        [TestMethod]
        public async Task GivenANewEndPoint_CallMustWork_WhenWeCallTheUrlAsync()
        {
            //Arrange
            string query = "/datastore_search?resource_id=5579bc8e-1e47-47ef-a06e-9f08da28dec8&limit=5";

            //Act
            var request = new RestRequest(query, DataFormat.Json);
            ApiResponseData response = await _client.GetAsync<ApiResponseData>(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Result.Records.Count() == 5);
        }
    }
}

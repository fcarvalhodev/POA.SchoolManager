using POA.SchoolManagerApplication.Models;
using System.Threading.Tasks;

namespace POA.SchoolManagerApplication.Services
{
    public interface ISchoolsService
    {
        Task<ApiResponse<SchoolModel>> GetAll();

        Task<ApiResponse<SchoolModel>> GetByQuery(SearchSchoolRequest request);
    }
}

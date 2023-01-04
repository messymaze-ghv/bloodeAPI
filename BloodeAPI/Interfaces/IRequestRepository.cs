using System;
using BloodeAPI.ViewModels.Request.RequestDTO;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.Interfaces
{
	public interface IRequestRepository
	{
        public Task<List<RequestResponse>>? FetchRequestsByCity(int id);
        public Task<List<RequestResponse>>? FetchMyRequests(int id);
        public Task<int> AddRequest(RequestDTO request);
        public Task<bool> UpdateDonarsList(int userId, int requestId);
        public Task<bool> MakeArchive(int requestId);   
        public IDictionary<String, String?> GetDonarsDetails(int requestId);
    }
}


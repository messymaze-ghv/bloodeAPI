using System;
using BloodeAPI.ViewModels.Request;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.Interfaces
{
	public interface IRequestRepository
	{
        public Task<List<RequestResponse>>? FetchRequestsByPlace(RequestDTO requestDTO);
        public Task<List<RequestResponse>>? FetchMyRequests(RequestDTO requestDTO);
        public Task<int> AddRequest(RequestDTO request);
        public Task<bool> UpdateDonarsList(RequestDTO request);
        public Task<bool> MakeArchive(RequestDTO requestDTO);   
    }
}


using System;
using AutoMapper;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.Utilities;
using BloodeAPI.ViewModels.Request.RequestDTO;
using BloodeAPI.ViewModels.Response;

namespace BloodeAPI.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlooddonateContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RequestRepository> _logger;


        public RequestRepository(BlooddonateContext context,ILogger<RequestRepository> logger,IMapper mapper)
        {
            this._context = context;
            this._mapper =  mapper;
            this._logger =  logger;
        }

        public async Task<int> AddRequest(RequestDTO request)
        {
            try
            {
                Request requestDBM = _mapper.Map<Request>(request);
                requestDBM.IsActive = true;
                requestDBM.CreatedDate = DateTime.UtcNow;
                requestDBM.LastUpdatedDate = DateTime.UtcNow;
                var result = await _context.AddAsync(requestDBM);
                await _context.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.InnerException!.Message);
                return -1;
            }


        }

        public Task<List<RequestResponse>>? FetchMyRequests(int id)
        {
            try
            {

                var requests = _context.Requests.Where(req => req.UserId == id && req.IsActive == true).ToList();
                List<RequestResponse> responses = new List<RequestResponse>();
                foreach (var request in requests)
                {
                    User? user = _context.Users.FirstOrDefault(usr => usr.Id == id);
                    List<int> donarsList = _context.RequestDonars.Where(req => req.RequestId == request.Id).Select(req => req.UserId).ToList();
                    var req_respone = new RequestResponse();
                    req_respone.BloodGroup = request.BloodGroup;
                    req_respone.RequestId = request.Id;
                    req_respone.RecipientName = user!.FirstName.Concatenate(user.LastName);
                    req_respone.isCreatedByLoggedInUser = true;
                    req_respone.isUserResponded = false;
                    req_respone.CreatedUserId = request.UserId;
                    req_respone.isActive = request.IsActive;
                    req_respone.PostedDate = request.CreatedDate;
                    req_respone.Location = request.Location;
                    req_respone.respondersCount = donarsList.Count;
                    responses.Add(req_respone);
                }
                return Task.FromResult(responses);
            }
            catch (Exception ex)
            {
               this._logger.LogError(ex.InnerException!.Message,ex.StackTrace);
                return null;
            }

        }

        public Task<List<RequestResponse>>? FetchRequestsByCity(int userId)
        {
            try
            {
                User? loggedInUser = _context.Users.FirstOrDefault(usr => usr.Id == userId);
                var requests = _context.Requests.Where(req => req.City == loggedInUser!.City && req.IsActive).ToList();
                List<RequestResponse> responses = new List<RequestResponse>();
                foreach (var request in requests)
                {
                    if (request.UserId != userId)
                    {
                        User? user = _context.Users.FirstOrDefault(usr => usr.Id == request.UserId);
                        List<int> donarsList = _context.RequestDonars.Where(req => req.RequestId == request.Id).Select(req => req.UserId).ToList();
                        var req_respone = new RequestResponse();
                        req_respone.BloodGroup = request.BloodGroup;
                        req_respone.RequestId = request.Id;
                        req_respone.RecipientName = user!.FirstName.Concatenate(user.LastName);
                        req_respone.isCreatedByLoggedInUser = false;
                        req_respone.isUserResponded = donarsList.Contains(userId);
                        req_respone.CreatedUserId = request.UserId;
                        req_respone.Location = request.Location;
                        //req_respone.respondersList = GetNamePhoneDictionary(donarsList);
                        responses.Add(req_respone);
                    }

                }
                return Task.FromResult(responses);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.InnerException!.Message, ex.StackTrace);
                return null;
            }

        }

        public IDictionary<String,String?> GetDonarsDetails(int requestId)
        {
            try
            {
                List<int> donarsIdsList = _context.RequestDonars.Where(req => req.RequestId == requestId).Select(req => req.UserId).ToList(); 
                return GetNamePhoneDictionary(donarsIdsList);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.InnerException!.Message, ex.StackTrace);
                return null;
            }
        }

        public async Task<bool> MakeArchive(int requestId)
        {
            try
            {
                var request = _context.Requests.FirstOrDefault(req => req.Id == requestId);
                request!.IsActive = false;
                request.LastUpdatedDate = DateTime.UtcNow;
                _context.Requests.Update(request);
                var archiveRequest = new RequestHistory();
                archiveRequest.Id = default;
                archiveRequest.RequestId = request.Id;
                archiveRequest.CreatedDate = DateTime.UtcNow;
                await _context.RequestHistories.AddAsync(archiveRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.InnerException!.Message, ex.StackTrace);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateDonarsList(int userId,int requestId)
        {
            try
            {
                var requestDonar = new RequestDonar();
                requestDonar.Id = default;
                requestDonar.RequestId = requestId;
                requestDonar.UserId = userId;
                requestDonar.CreatedDate = DateTime.UtcNow;
                await _context.RequestDonars.AddAsync(requestDonar);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.InnerException!.Message, ex.StackTrace);
                return false;
            }
            return true;
        }

        

        private IDictionary<string, string?> GetNamePhoneDictionary(IEnumerable<int> userIds)
        {
            return _context.Users.Where(u => userIds.Contains(u.Id)).ToDictionary(u => u.FirstName.Concatenate(u.LastName), u => u.PhoneNumber);
        }
    }
}


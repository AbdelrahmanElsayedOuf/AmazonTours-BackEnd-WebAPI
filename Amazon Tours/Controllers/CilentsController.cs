using Amazon_Tours.Utilities.ApiResponses.Interfaces;
using AmazonTours.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmazonTours.Application.DTOs.ReadDTOs;
using Amazon_Tours.Utilities.ApiResponses.Factory;
using System.Net;
namespace Amazon_Tours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CilentsController : ControllerBase
    {
        private readonly IClientService clientService;

        public CilentsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route("GetAllCilents")]
        public async Task<IApiResponse<List<ClientDTO>>> GetAllClients()
        {
            var allClients = await clientService.GetAllAsync(client => client.City, client => client.Country);
            if(allClients.Count() == 0)
                return ApiResponseFactory<List<ClientDTO>>.FailureResponse(null,HttpStatusCode.NotFound,"Not Found");

            var allClinetsDtos = allClients.Select(clinet => new ClientDTO
            {
                Id = clinet.Id,
                FName = clinet.FName,
                LName = clinet.LName,
                Gender = clinet.Gender,
                CityName = clinet.City.Name,
                CountryName = clinet.Country.Name,
                IsAvailable = clinet.IsAvailable
            }).ToList();

            return ApiResponseFactory<List<ClientDTO>>.SuccessResponse(allClinetsDtos, HttpStatusCode.OK, "success");
        }

      /*  [HttpGet]
        [Route("GetClientById/{id:guid}")]
        public async Task<IApiResponse<ClientDTO>> GetClientById(Guid id)
        {
            var client = await clientService.GetByIdAsync(id);
            if (client == null)
                return ApiResponseFactory<ClientDTO>.FailureResponse(null, HttpStatusCode.NotFound, "Not Found");

            return ApiResponseFactory<ClientDTO>.SuccessResponse(client, HttpStatusCode.OK, "success");
        }*/
    }
}

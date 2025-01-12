﻿using Newtonsoft.Json;
using Mango.Web.Service.IService;
using Mango.Web.Models;
using static  Mango.Web.Utility.SD;
using System.Net;
namespace Mango.Web.Service
{
	public class BaseService : IBaseService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BaseService(IHttpClientFactory httpContextFactory)
		{
			_httpClientFactory = httpContextFactory;
		}
		public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
		{
			try {
				HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
				HttpRequestMessage message = new();
				message.Headers.Add("Accept", "application/json");
				//token

				message.RequestUri = new Uri(requestDto.Url);

				if (requestDto.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), System.Text.Encoding.UTF8, "application/json");

				}

				HttpResponseMessage? apiResponse = null;


				switch (requestDto.ApiType)
				{

					case ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}

				apiResponse = await client.SendAsync(message);




				switch (apiResponse.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new()
						{
							IsSuccess = false,
							Message = "Not Found"
						};
						break;
					case HttpStatusCode.Forbidden:
						return new()
						{
							IsSuccess = false,
							Message = "access Denied"
						};
						break;
					case HttpStatusCode.Unauthorized:
						return new()
						{
							IsSuccess = false,
							Message = "Unauthorized"
						};
						break;
					case HttpStatusCode.InternalServerError:
						return new()
						{
							IsSuccess = false,
							Message = "InternalServerError"
						};
						break;
					default:
						var apiContent = await apiResponse.Content.ReadAsStringAsync();
						var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
						return apiResponseDto;


				}
			} catch(Exception ex)
			{
				var dto = new ResponseDto
				{
					Message = ex.Message,
					IsSuccess = false

				};
				return dto;

			}
	}
	}


}
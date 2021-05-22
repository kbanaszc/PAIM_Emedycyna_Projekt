namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ExaminationRoomsServiceClient : IExaminationRoomsServiceClient
    {
        public IHttpClientFactory clientFactory;
        public ExaminationRoomsServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ExaminationRoomDto>> GetAllExaminationRoomsAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44391/examination-rooms");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<ExaminationRoomDto>>(responseStream, options);
        }
    }
}


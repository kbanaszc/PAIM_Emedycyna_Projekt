namespace ExaminationRoomsSelector.Web.Application.DataServiceClients
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IExaminationRoomsServiceClient
    {
        Task<IEnumerable<ExaminationRoomDto>> GetAllExaminationRoomsAsync();
    }
}

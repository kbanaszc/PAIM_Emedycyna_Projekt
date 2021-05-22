namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IExaminationRoomsSelectorHandler
    {
        List<List<string>> Logic(List<List<string>> RoomsCertifcationsList, List<List<string>> DoctorsSpecjalizationsList);
        List<List<string>> GetExaminationRoomsSelection();
        List<List<string>> GetAllExaminationRooms(IEnumerable<ExaminationRoomDto> rooms);
        List<List<string>> GetAllDoctors(IEnumerable<DoctorsDto> doctors);
        Task<IEnumerable<ExaminationRoomDto>> GetExaminatiomRoomsDtoAsync();
        Task<IEnumerable<DoctorsDto>> GetDoctorsDtoAsync();
    }
}

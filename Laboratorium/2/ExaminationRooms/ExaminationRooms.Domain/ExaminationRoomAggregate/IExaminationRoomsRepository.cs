namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IExaminationRoomsRepository
    {
        Task<IEnumerable<ExaminationRoom>> GetAllAsync();
        IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType);
        Task AddExaminationRoomAsync(ExaminationRoom examinationRoom);
    }
}

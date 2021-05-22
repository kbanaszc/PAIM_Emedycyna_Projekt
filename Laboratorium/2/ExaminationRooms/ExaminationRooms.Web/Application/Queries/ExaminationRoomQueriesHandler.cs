namespace ExaminationRooms.Web.Application
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomQueriesHandler : IExaminationRoomQueriesHandler
    {
        private readonly IExaminationRoomsRepository examinationRoomsRepository;

        public ExaminationRoomQueriesHandler(IExaminationRoomsRepository examinationRoomsRepository)
        {
            this.examinationRoomsRepository = examinationRoomsRepository;
        }

        public async Task<IEnumerable<ExaminationRoomDto>> GetAllAsync()
        {
            return (await examinationRoomsRepository.GetAllAsync()).Select(r=>r.Map());
        }

        public IEnumerable<ExaminationRoomDto> GetByCertificationType(int certificationType)
        {
            return examinationRoomsRepository.GetByCertificationType(certificationType)?.Select(ld=>ld.Map());
        }
    }
}

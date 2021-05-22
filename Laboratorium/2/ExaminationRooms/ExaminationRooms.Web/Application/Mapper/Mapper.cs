namespace ExaminationRooms.Web.Application.Mapper
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static ExaminationRoomDto Map(this ExaminationRoom examinationRoom)
        {
            if (examinationRoom == null)
                return null;

            return new ExaminationRoomDto
            {
                Number = examinationRoom.Number,
                Certifications = examinationRoom?.Certifications.Select(s => s.Type.ToString())
            };
        }
    }
}

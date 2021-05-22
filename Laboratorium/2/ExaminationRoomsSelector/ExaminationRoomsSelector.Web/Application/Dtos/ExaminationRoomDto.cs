namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomDto
    {
        public ExaminationRoomDto()
        {
        }
        public ExaminationRoomDto(string number, IEnumerable<string> certifications)
        {
            Number = number;
            Certifications = certifications;
        }

        public string Number { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}

namespace ExaminationRooms.Web.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}

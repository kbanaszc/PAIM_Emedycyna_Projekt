namespace ExaminationRooms.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //wykorzystujemy interfejs wskaźnikowy ICommand do jawnego wskazania, że dana klasa jest komendą
    public class AddExaminationRoomCommand : ICommand
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}

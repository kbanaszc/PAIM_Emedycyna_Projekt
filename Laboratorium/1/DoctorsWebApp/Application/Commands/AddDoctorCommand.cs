namespace DoctorsWebApp.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //wykorzystujemy interfejs wskaźnikowy ICommand do jawnego wskazania, że dana klasa jest komendą
    public class AddDoctorCommand : ICommand
    {
        public string Name { get; set; }
        public IEnumerable<int> Specjalizations { get; set; }
    }
}

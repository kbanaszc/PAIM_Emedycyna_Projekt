namespace DoctorsWebApp.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PAIM_wyk1;

    //"handler" komendy tworzenia doktora
    public class DoctorsCommandsHandler : ICommandHandler<AddDoctorCommand>
    {
        private readonly IDoctorsRepository doctorsRepository;

        public DoctorsCommandsHandler(IDoctorsRepository doctorsRepository)
        {
            this.doctorsRepository = doctorsRepository;
        }

        public void Handle(AddDoctorCommand command)
        {
            var specjalizations = new List<Specjalization>();

            foreach (var specjalization in command.Specjalizations)
                specjalizations.Add(new Specjalization(0, "specjalizacja"+specjalization, specjalization));

            doctorsRepository.AddDoctorAsync(new Doctor(0, command.Name, specjalizations));
        }
    }
}

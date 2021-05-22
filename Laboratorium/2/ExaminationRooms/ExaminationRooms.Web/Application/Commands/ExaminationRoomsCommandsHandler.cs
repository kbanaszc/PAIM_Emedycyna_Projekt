namespace ExaminationRooms.Web.Application.Commands
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //"handler" komendy tworzenia gabinetu
    public class ExaminationRoomsCommandsHandler : ICommandHandler<AddExaminationRoomCommand>
    {
        private readonly IExaminationRoomsRepository examinationRoomsRepository;

        public ExaminationRoomsCommandsHandler(IExaminationRoomsRepository examinationRoomsRepository) 
        {
            this.examinationRoomsRepository = examinationRoomsRepository;
        }

        public void Handle(AddExaminationRoomCommand command)
        {
            var certifications = new List<Certification>();

            foreach (var certification in command.Certifications)
                certifications.Add(new Certification(0, DateTime.UtcNow, certification));

            examinationRoomsRepository.AddExaminationRoomAsync(new ExaminationRoom(0,command.Number,certifications));
        }
    }
}

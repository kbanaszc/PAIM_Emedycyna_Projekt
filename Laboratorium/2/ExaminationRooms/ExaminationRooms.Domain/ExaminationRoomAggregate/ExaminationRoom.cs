namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using ExaminationRooms.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExaminationRoom : Entity
    {
        public string Number { get; private set; }
        public IList<Certification> Certifications { get; private set; } = new List<Certification>();

        public ExaminationRoom(int id, string number) : base(id)
        {
            Number = number;
        }


        public ExaminationRoom(int id, string number, IList<Certification> certifications) : this(id, number)
        {
            Certifications = certifications;
        }

        public void AddCertification(Certification certification)
        {
            Certifications.Add(certification);
        }
        public void AddCertifications(IEnumerable<Certification> certifications)
        {
            foreach(var certification in certifications)
                Certifications.Add(certification);
        }
    }
}

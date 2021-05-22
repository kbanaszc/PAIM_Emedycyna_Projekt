namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using ExaminationRooms.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Certification : Entity
    {
        public DateTime GrantedAt { get; private set; }
        public int Type {get; private set;}

        public Certification(int id, DateTime grantedAt, int type) : base(id)
        {
            GrantedAt = grantedAt;
            Type = type;
        }
    }
}

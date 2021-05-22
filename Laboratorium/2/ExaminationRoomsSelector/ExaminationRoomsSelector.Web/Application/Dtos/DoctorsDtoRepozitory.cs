using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationRoomsSelector.Web;
using ExaminationRoomsSelector.Web.Application.Dtos;

namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class DoctorsDtoRepozitory
    {
        List<DoctorsDto> doctorsDtoForTestList = new();
        public List<DoctorsDto> DoctorsDtoFactory() 
        {
            for (int i = 0; i < 50; i++)
            {
                int y = i%14;
                var newDocDto = new DoctorsDto("Oetker" + i.ToString(), new string[] { y.ToString() });
                doctorsDtoForTestList.Add(newDocDto);
            }
            return doctorsDtoForTestList;
        }
            
    }
}

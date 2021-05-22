namespace PAIM_wyk1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IDoctorsRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        IEnumerable<Doctor> GetBySpecType(int SpecType);
        Task AddDoctorAsync(Doctor doctor);
    }
}

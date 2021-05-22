namespace ClassLibrary
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PAIM_wyk1;
    using System.Data.Common;
    using Dapper;

    public class DoctorRepository : IDoctorsRepository
    {

        public DoctorRepository()
        {
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";

            //utworzenie połączenia do bazy danych, klauzula using wykorzystywana jest żebyśmy nie musieli przejmować się zamykaniem polączenia
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                //otwarcie połączenia 
                dbConnection.Open();

                //utworzenie transakcji - będziemy wstawiać dane do trzech różnych tabel
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string insertDoctorQuery = @"INSERT INTO Doctor (Name) VALUES (@name);";
                        //wykonanie zapytania sql, korzystamy tutaj z Dappera - pakietu ułatwiającego korzystanie z baz danych
                        int doctorId = await dbConnection.QueryFirstAsync<int>(insertDoctorQuery + ";" + getAddedRowIdQueryQuery, new { name = doctor.Name }, transaction);

                        var specjalizationsIds = new List<int>();

                        const string insertSpecjalizationQuery = @"INSERT INTO Specjalization (specName, Type) VALUES (@specName,@type);";
                        foreach (var specjalization in doctor.Specjalizations)
                            specjalizationsIds.Add(await dbConnection.QueryFirstAsync<int>(insertSpecjalizationQuery + ";" + getAddedRowIdQueryQuery, new { specName = specjalization.SpecName, type = specjalization.Type }, transaction));

                        const string insertDoctorSpecjalizationQuery = @"INSERT INTO DoctorSpecjalization (DoctorId, SpecjalizationId) VALUES (@doctorId,@specjalizationId);";
                        foreach (var specjalizationId in specjalizationsIds)
                            await dbConnection.QueryAsync(insertDoctorSpecjalizationQuery, new { doctorId = doctorId, specjalizationId = specjalizationId }, transaction);
                        //commit transakcji
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                //otwarcie połączenia tym razem nie jest konieczne, Dapper zrobi to automatycznie w razie potrzeby
                //poprzednim razem otwarcia połączenia wymagało utworzenie transakcji
                const string selectDoctorSpecjalizationQuery = @"SELECT * FROM DoctorSpecjalization";

                var doctorsSpecjalizations = (await dbConnection.QueryAsync(selectDoctorSpecjalizationQuery)).Select(x => new { SpecjalizationId = x.SpecjalizationId, DoctorId = x.DoctorId });

                const string selectDoctorQuery = @"SELECT * FROM Doctor";

                var doctors = await dbConnection.QueryAsync<Doctor>(selectDoctorQuery);

                const string selectSpecjalizationsQuery = @"SELECT * FROM Specjalization";

                var specjalizations = await dbConnection.QueryAsync<Specjalization>(selectSpecjalizationsQuery);

                foreach (var doctor in doctors)
                {
                    var specjalizationsIdForDoctor = doctorsSpecjalizations.Where(x => x.DoctorId == doctor.Id).Select(x => x.SpecjalizationId);
                    var specjalizationsForDoctor = specjalizations.Where(x => specjalizationsIdForDoctor.Contains(x.Id));
                    doctor.AddSpecjalizations(specjalizationsForDoctor);
                }

                return doctors;
            }
        }

        public IEnumerable<Doctor> GetBySpecType(int specType)
        {
            throw new NotImplementedException();
        }
    }
}


namespace ExaminationRooms.Infrastructure
{
    using Dapper;
    using ExaminationRooms.Domain;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExaminationRoomsRepository : IExaminationRoomsRepository
    {

        public ExaminationRoomsRepository()
        {
        }

        public async Task AddExaminationRoomAsync(ExaminationRoom examinationRoom)
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
                        const string insertExaminationRoomQuery = @"INSERT INTO ExaminationRoom (Number) VALUES (@number);";
                        //wykonanie zapytania sql, korzystamy tutaj z Dappera - pakietu ułatwiającego korzystanie z baz danych
                        int examinationRoomId = await dbConnection.QueryFirstAsync<int>(insertExaminationRoomQuery + ";" + getAddedRowIdQueryQuery, new { number = examinationRoom.Number }, transaction);

                        var certificationsIds = new List<int>();

                        const string insertCertificationQuery = @"INSERT INTO Certification (Type, GrantedAt) VALUES (@type,@grantedAt);";
                        foreach (var certifition in examinationRoom.Certifications)
                            certificationsIds.Add(await dbConnection.QueryFirstAsync<int>(insertCertificationQuery + ";" + getAddedRowIdQueryQuery, new { type = certifition.Type, grantedAt = certifition.GrantedAt }, transaction));

                        const string insertExamitionRoomCertificationQuery = @"INSERT INTO ExaminationRoomCertification (ExaminationRoomId, CertificationId) VALUES (@examinationRoomId,@certificationId);";
                        foreach (var certifitionId in certificationsIds)
                            await dbConnection.QueryAsync(insertExamitionRoomCertificationQuery, new { examinationRoomId = examinationRoomId, certificationId = certifitionId }, transaction);
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


        public async Task<IEnumerable<ExaminationRoom>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                //otwarcie połączenia tym razem nie jest konieczne, Dapper zrobi to automatycznie w razie potrzeby
                //poprzednim razem otwarcia połączenia wymagało utworzenie transakcji
                const string selectExaminationRoomCertificationQuery = @"SELECT * FROM ExaminationRoomCertification";

                var examinationRoomsCertificates = (await dbConnection.QueryAsync(selectExaminationRoomCertificationQuery)).Select(x => new { CertificationId = x.CertificationId, ExaminationRoomId = x.ExaminationRoomId });

                const string selectExaminationRoomQuery = @"SELECT * FROM ExaminationRoom";

                var examinationRooms = await dbConnection.QueryAsync<ExaminationRoom>(selectExaminationRoomQuery);

                const string selectCertificationsQuery = @"SELECT * FROM Certification";

                var certifications = await dbConnection.QueryAsync<Certification>(selectCertificationsQuery);

                foreach (var examinationRoom in examinationRooms)
                {
                    var certificationsIdForGivenRoom = examinationRoomsCertificates.Where(x => x.ExaminationRoomId == examinationRoom.Id).Select(x => x.CertificationId);
                    var certificationsForGivenRoom = certifications.Where(x => certificationsIdForGivenRoom.Contains(x.Id));
                    examinationRoom.AddCertifications(certificationsForGivenRoom);
                }

                return examinationRooms;
            }
        }

        public IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType)
        {
            throw new NotImplementedException();
        }
    }
}

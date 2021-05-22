@echo off

echo Pobranie wszystkich pacjentów:
curl -X GET "https://localhost:44391/GetAllPatients" -H  "accept: text/plain"
echo. 
echo.

echo Pobranie wszystkich recept"
curl -X GET "https://localhost:44391/GetAllPrescriptions" -H  "accept: text/plain"
echo.
echo.

echo Pobranie recepty dla pacjenta o numerze pesel = 00000000001"
curl -X GET "https://localhost:44391/GetPrescriptions?pesel=00000000001" -H  "accept: text/plain"
echo.
echo.

echo Pobranie wizyt dla danego lekarza o id = 1"
curl -X GET "https://localhost:44391/GetVisits?doctorId=1" -H  "accept: text/plain"
echo.
echo.

pause
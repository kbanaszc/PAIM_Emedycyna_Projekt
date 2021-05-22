@echo off

echo Pobranie wszystkich pacjentów
curl -X GET "https://localhost:44345/GetAllPatients" -H  "accept: text/plain"
echo. 
echo.

echo Pobranie pacjenta o id 0:
curl -X GET "https://localhost:44345/GetPatientById?patientId=1" -H  "accept: text/plain"
echo. 
echo.

pause
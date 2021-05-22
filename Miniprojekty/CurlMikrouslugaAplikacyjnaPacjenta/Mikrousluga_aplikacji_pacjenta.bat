@echo off

echo Pobranie recept pacjenta o id 0:
curl -X GET "https://localhost:44329/GetAllPrescriptions?patientId=0" -H  "accept: text/plain"
echo. 
echo.

echo Pobranie wizyt pacjenta o id 0:
curl -X GET "https://localhost:44329/GetAllVisits?patientId=0" -H  "accept: text/plain"
echo. 
echo.

pause
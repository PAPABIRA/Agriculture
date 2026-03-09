@echo off
echo Execution du script pour creer la table Lieux...
echo.
echo Veuillez entrer votre mot de passe MySQL lorsque demande.
echo.

REM Remplacez "root" par votre nom d'utilisateur MySQL si different
mysql -u root -p bdsenagriculture < creer_table_lieux.sql

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Script execute avec succes !
    echo La table Lieux a ete creee.
) else (
    echo.
    echo Erreur lors de l'execution du script.
    echo Verifiez vos identifiants MySQL.
)

pause

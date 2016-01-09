Il progetto utilizza le database migration di `Entity Framework`. Per allineare il database alla struttura richiesta dal progetto è necessario eseguire, dalla `Package Manager Console` di Visual Studio, il seguente comando:

```
Update-Database -StartUpProjectName "Duo.Migrations" -ProjectName "Duo.Migrations" -Verbose
``` 
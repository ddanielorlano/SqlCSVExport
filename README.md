# SqlCSVExport
This program provides a way to export a SQL Server Table to .txt or .CSV.
The Exporter Class is the Model to the Windows Form.
It works by generating a SQL Server connection string - https://www.connectionstrings.com/sql-server/ - 
and using that to connect to the db and execute a SELECT * FROM "Table Entered".

It is lacking proper error handling.

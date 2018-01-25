USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='CarDealarship')
DROP DATABASE CarDealarship
GO

CREATE DATABASE CarDealarship
GO
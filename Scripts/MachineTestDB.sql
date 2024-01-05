create database SampleDemo

use SampleDemo

create table Employee(id int identity(1,1)primary key,Name Varchar(30)not null,Department Varchar(50)not null)

Insert Into Employee(Name,Department)
Values('Niswin','Asp.Net')

Select * from Dbo.Employee

create table Tasks(id int identity(1000,1)primary key,Taskname Varchar(50)not null,Description Varchar(150)not null)

Insert Into Tasks(Taskname,Description)
Values('Machine Test','Asp.Net MVC Machine Test')

Select * from Dbo.Tasks
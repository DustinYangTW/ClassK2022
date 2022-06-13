create database School
go

use School
go

create table Student(
	StuID char(4) primary key not null,
	StuName nvarchar(20) not null,
   StuGender bit not null,
   Tel varchar(20),
   Birthday datetime,
   Age as datediff(year,Birthday,getdate())
)

create table Course(
    CourseID char(5) primary key,
	CourseName nvarchar(30) not null,
	Credit tinyint not null
)

create table Employee(
	ID char(10) primary key,
	EmpName nvarchar(20) not null,
	City nvarchar(5) not null,
	Street nvarchar(30) not null,
	Tel varchar(20),
	Salary money default 26500,
   Insurance money not null,
   tax as Salary * 0.05,
   pay as Salary - Insurance - Salary * 0.05
)

--identity
create table Professors(
	SN bigint identity(100,10), 
	ProfessorsID char(4) primary key,
	JobTitle nvarchar(10) not null,
	Deparment nvarchar(10) not null,
	ID char(10) not null
)


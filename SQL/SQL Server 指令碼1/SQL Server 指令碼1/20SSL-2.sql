--Contraints(±ø¥ó¬ù§ô)
primary key Constraints
create table Orders(
	OrderID char(8) primary key,
	OrderData datetime not null,
	CustomerID char(5) not null
)

create table Products(
	ProductID char(8) primary key,
	ProductName nvarchar(30) not null,
	UnitPrice money not null
)

create table OrderDetails(
	OrderID char(8),
	ProductID char(8),
	UnitPrice money not null,
	Quantity int not null,
	UnitTotal as UnitPrice * Quantity,
	primary key(OrderID,ProductID)
)
--Unique constraint
create table Custimers(
	CustomerID char(5) primary key,
	CustomerName nvarchar(20) not null,
	Account varchar(20) not null unique
)

--check Constraint
create table ProductType(
	ProductTypeID char(2) primary key,
	ProductTypeName nvarchar(50) not null,
	ProductTypeValue int not null default 0 constraint CK_ProductTypeValueNoLessThenZero check(ProductTypeValue>=0)
)



--Foreign key constraint

create table Classes(
	StuNo char(4),
	CourseID char(5),
	ProfessorID char(4),
	ClassTime datetime not null,
	Classroom varchar(8) not null,
	foreign key(StuNo) references Student(StuID) on delete no action on update no action,
	foreign key(CourseID) references Course(CourseID) on delete cascade on update cascade,
	foreign key(ProfessorID) references Professors(ProfessorsID) on delete cascade on update no action
)

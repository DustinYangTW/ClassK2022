--修改資料表定義
--alter
alter table Orders
	add foreign key(CustomerID) references Customers(CustomerID) on delete no action on update no action

alter table Products
	add foreign key(Pro) references Customers(CustomerID) on delete no action on update no action
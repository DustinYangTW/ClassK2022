--修改資料表定義
--alter
--alter
alter table Orders
	add foreign key(CustomerID) references Customers(CustomerID) on delete no action on update no action

alter table OrderDetails
	add foreign key(OrderID) references Orders(OrderID) on delete no action on update no action


alter table OrderDetails
	add foreign key(ProductID) references Products(ProductID) on delete no action on update no action

alter table Products
	add ProductTypeID char(2) not null

alter table Products
	add foreign key(ProductTypeID) references ProductType(ProductTypeID) on delete no action on update no action

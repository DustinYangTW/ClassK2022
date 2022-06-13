select *
from Orders
select *
from Employees

select epl.LastName,epl.FirstName,od.*
from Orders as od
inner join Employees as epl on od.EmployeeID = epl.EmployeeID

--�έp�U�ȤU�L�X���q��
select c.CompanyName,o.CustomerID,count(*) as '�U�榸��'
from Orders as o
inner join Customers as c on c.CustomerID = o.CustomerID
group by c.CompanyName,o.CustomerID
order by �U�榸�� desc

--�έp�C����u�̹L�X���q��
select o.EmployeeID,e.LastName,e.FirstName,e.Title,count(*) as ���u�B�z�q�浧��
from Orders as o
inner join Employees as e on o.EmployeeID = e.EmployeeID
group by o.EmployeeID,e.LastName,e.FirstName,e.Title
order by ���u�B�z�q�浧�� desc

select *
from Employees
select * 
from Orders
select * 
from Customers
select *
from [Order Details]

--�έp�C�i�q�檺�`�B�A�åѤj��p�Ƨ�
select c.CompanyName, Round(sum(od.UnitPrice*(1-od.Discount)),2) as �q���`�B
from [Order Details] as od
inner join Orders as o on o.OrderID = od.OrderID
inner join Customers as c on o.CustomerID = c.CustomerID
group by c.CompanyName
order by �q���`�B desc

select * 
from Shippers
select * 
from Orders

--�[�W�Ȥ�W�١A���u�m�W�P�B�e�覡
select ep.LastName,ep.FirstName,c.CompanyName,sp.CompanyName as shipper, Round(sum(od.UnitPrice*(1-od.Discount)),2) as �q���`�B
from [Order Details] as od
inner join Orders as o on o.OrderID = od.OrderID
inner join Customers as c on o.CustomerID = c.CustomerID
inner join Employees as ep on ep.EmployeeID = o.EmployeeID
inner join Shippers as sp on sp.ShipperID =o.ShipVia
group by sp.CompanyName,ep.LastName,ep.FirstName,c.CompanyName
order by �q���`�B desc
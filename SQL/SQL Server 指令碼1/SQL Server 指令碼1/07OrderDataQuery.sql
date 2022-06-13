select *
from Orders
select *
from Employees

select epl.LastName,epl.FirstName,od.*
from Orders as od
inner join Employees as epl on od.EmployeeID = epl.EmployeeID

--統計顧客下過幾次訂單
select c.CompanyName,o.CustomerID,count(*) as '下單次數'
from Orders as o
inner join Customers as c on c.CustomerID = o.CustomerID
group by c.CompanyName,o.CustomerID
order by 下單次數 desc

--統計每位員工裡過幾筆訂單
select o.EmployeeID,e.LastName,e.FirstName,e.Title,count(*) as 員工處理訂單筆數
from Orders as o
inner join Employees as e on o.EmployeeID = e.EmployeeID
group by o.EmployeeID,e.LastName,e.FirstName,e.Title
order by 員工處理訂單筆數 desc

select *
from Employees
select * 
from Orders
select * 
from Customers
select *
from [Order Details]

--統計每張訂單的總額，並由大到小排序
select c.CompanyName, Round(sum(od.UnitPrice*(1-od.Discount)),2) as 訂單總額
from [Order Details] as od
inner join Orders as o on o.OrderID = od.OrderID
inner join Customers as c on o.CustomerID = c.CustomerID
group by c.CompanyName
order by 訂單總額 desc

select * 
from Shippers
select * 
from Orders

--加上客戶名稱，員工姓名與運送方式
select ep.LastName,ep.FirstName,c.CompanyName,sp.CompanyName as shipper, Round(sum(od.UnitPrice*(1-od.Discount)),2) as 訂單總額
from [Order Details] as od
inner join Orders as o on o.OrderID = od.OrderID
inner join Customers as c on o.CustomerID = c.CustomerID
inner join Employees as ep on ep.EmployeeID = o.EmployeeID
inner join Shippers as sp on sp.ShipperID =o.ShipVia
group by sp.CompanyName,ep.LastName,ep.FirstName,c.CompanyName
order by 訂單總額 desc
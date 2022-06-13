select ProductID
from [Order Details]
where OrderID=10847

select *
from Products
where UnitsInStock < ReorderLevel and  UnitsOnOrder = 0

select *
from Orders
where ShippedDate Is Null


select *
from Products

select *
from Products
where UnitsOnOrder between 20 and 40

select *
from [Order Details]
where OrderID = '10263'

select *
from Products
select *
from Suppliers

select sp.CompanyName,COUNT(*) as '商品量'
from Products as pd
inner join  Suppliers as sp on sp.SupplierID = pd.SupplierID
group by sp.CompanyName


select SupplierID ,count(*) as '購買次數'
from Products
group by SupplierID


select *
from Products
select *
from Customers
select *
from Orders

select cm.ContactName,COUNT(*) as '服務次數'
from Customers as cm
inner join  Orders as ods on cm.CustomerID = ods.CustomerID
group by cm.ContactName

select *
from Products
select *
from [Order Details]
select * 
from Orders
select *
from Products

--select  pd.ProductName,ROUND(AVG(odds.UnitPrice*(1-odds.Discount)),2) as 平均單價
--from [Order Details] as odds
--inner join Products as pd on pd.UnitPrice = odds.UnitPrice
--group by odds.UnitPrice,odds.Discount,pd.ProductName

select pd.ProductID, pd.ProductName,ROUND(AVG(odds.UnitPrice*(1-odds.Discount)),2) as '平均單價',
AVG(odds.Quantity) as '平均銷售數量'
from Products as pd
inner join [Order Details] as odds on pd.UnitPrice = odds.UnitPrice
group by pd.ProductName,pd.ProductID
having AVG(odds.Quantity) > 10
order by pd.ProductID


select OrderID ,count(*)
from [Order Details]
group by OrderID 
having count(*) >= 5

select*
from [Order Details]
where Quantity >=5
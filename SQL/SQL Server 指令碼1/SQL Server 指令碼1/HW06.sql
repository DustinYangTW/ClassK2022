--請試寫一合併查詢，查詢出訂購日期落在1996年7月並 ok
--送貨公司「United Package」的有訂單之訂貨明細資料，並列出訂單號碼、產品類別名稱、
--產品名稱、產品訂購單價、產品訂購數量、產品價錢小計、客戶編號、客戶名稱、
--收貨人名字、訂購日期、處理訂單員工的姓名、送貨方式、供應商名稱等資料項目
--，其中產品價錢小計請以四捨五入計算至整數位。

select od.OrderID as '訂單號碼',cg.CategoryName as '產品類別名稱',
pd.ProductName as '產品名稱',odd.UnitPrice as '產品訂購單價',odd.Quantity as '產品訂購數量',
Round((odd.UnitPrice*(1-odd.Discount))*odd.Quantity,0) as '產品價錢小計',
ct.CustomerID as '客戶編號',ct.ContactName as '客戶名稱',--客戶編號
od.ShipName as '收貨人名稱',od.OrderDate as '訂購日期',--收貨人,訂購日期
ep.FirstName+' '+ep.LastName as '員工名稱', --員工
sp.CompanyName as '送貨方式',spy.CompanyName as '供應商名稱'
from Orders as od
inner join [Order Details] as odd on odd.OrderID = od.OrderID
inner join Shippers as sp on od.ShipVia =sp.ShipperID
inner join Products as pd on pd.ProductID = odd.ProductID
inner join Employees as ep on ep.EmployeeID = od.EmployeeID
inner join Customers as ct on ct.CustomerID = od.CustomerID
inner join Suppliers as spy on spy.SupplierID = pd.SupplierID
inner join Categories as cg on cg.CategoryID = pd.CategoryID
where od.OrderDate between '1996/07/01' and '1996/07/31' and sp.CompanyName = 'United Package'

--2.請試寫一合併查詢，查詢客戶ANTON歷年來所訂購的所有產品，並統計出各種產品的訂購數量，輸出如下結果。
select 
ct.CustomerID,ct.ContactName,
pd.ProductName,sum(odd.Quantity) as 'Quantity'
from Orders as od
inner join [Order Details] as odd on odd.OrderID = od.OrderID
inner join Products as pd on pd.ProductID = odd.ProductID
inner join Customers as ct on ct.CustomerID = od.CustomerID
group by ct.CustomerID,ct.ContactName,pd.ProductName
having ct.CustomerID = 'ANTON'
order by pd.ProductName


--3.請利用exists運算子配合子查詢式，
--找出哪些客戶從未下過訂單，並列出客戶的所有欄位。
--(不可用到in運算，亦不可用合併查詢式)
select * from Customers
where not exists(
select * from Orders 
where Customers.CustomerID = Orders.CustomerID
)

--4.請利用in運算子配合子查詢式，查詢哪些員工有處理過訂單，
--並列出員工的員工編號、姓名、職稱、內部分機號碼、附註欄位。
--(不可用到exists運算，亦不可用合併查詢式) 
select EmployeeID,FirstName+' '+LastName as '姓名',Title,Extension,Notes
from Employees
where EmployeeID in(
select EmployeeID 
from Orders
)

--5. 請合併查詢與子查詢兩種寫法，
--列出1998年度所有被訂購過的產品資料，並列出產品的所有欄位，且依產品編號由小到大排序。
--(寫合併查詢時不得用任何子查詢式，寫子查詢時不得用任何合併查詢式)

--5-1合併查詢
select distinct pd.*
from Products as pd
inner join [Order Details] as odd on pd.ProductID = odd.ProductID
inner join Orders as od on od.OrderID = odd.OrderID
where od.OrderDate between '1998/01/01' and '1998/12/31'
order by pd.ProductID

--5-2子查詢
select *
from Products
where ProductID in (
select ProductID
from [Order Details]
where OrderID in(
select OrderID
from Orders
where OrderDate between '1998/01/01' and '1998/12/31'
))
order by ProductID
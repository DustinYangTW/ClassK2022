--�иռg�@�X�֬d�ߡA�d�ߥX�q�ʤ�����b1996�~7��� ok
--�e�f���q�uUnited Package�v�����q�椧�q�f���Ӹ�ơA�æC�X�q�渹�X�B���~���O�W�١B
--���~�W�١B���~�q�ʳ���B���~�q�ʼƶq�B���~�����p�p�B�Ȥ�s���B�Ȥ�W�١B
--���f�H�W�r�B�q�ʤ���B�B�z�q����u���m�W�B�e�f�覡�B�����ӦW�ٵ���ƶ���
--�A�䤤���~�����p�p�ХH�|�ˤ��J�p��ܾ�Ʀ�C

select od.OrderID as '�q�渹�X',cg.CategoryName as '���~���O�W��',
pd.ProductName as '���~�W��',odd.UnitPrice as '���~�q�ʳ��',odd.Quantity as '���~�q�ʼƶq',
Round((odd.UnitPrice*(1-odd.Discount))*odd.Quantity,0) as '���~�����p�p',
ct.CustomerID as '�Ȥ�s��',ct.ContactName as '�Ȥ�W��',--�Ȥ�s��
od.ShipName as '���f�H�W��',od.OrderDate as '�q�ʤ��',--���f�H,�q�ʤ��
ep.FirstName+' '+ep.LastName as '���u�W��', --���u
sp.CompanyName as '�e�f�覡',spy.CompanyName as '�����ӦW��'
from Orders as od
inner join [Order Details] as odd on odd.OrderID = od.OrderID
inner join Shippers as sp on od.ShipVia =sp.ShipperID
inner join Products as pd on pd.ProductID = odd.ProductID
inner join Employees as ep on ep.EmployeeID = od.EmployeeID
inner join Customers as ct on ct.CustomerID = od.CustomerID
inner join Suppliers as spy on spy.SupplierID = pd.SupplierID
inner join Categories as cg on cg.CategoryID = pd.CategoryID
where od.OrderDate between '1996/07/01' and '1996/07/31' and sp.CompanyName = 'United Package'

--2.�иռg�@�X�֬d�ߡA�d�߫Ȥ�ANTON���~�өҭq�ʪ��Ҧ����~�A�òέp�X�U�ز��~���q�ʼƶq�A��X�p�U���G�C
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


--3.�ЧQ��exists�B��l�t�X�l�d�ߦ��A
--��X���ǫȤ�q���U�L�q��A�æC�X�Ȥ᪺�Ҧ����C
--(���i�Ψ�in�B��A�礣�i�ΦX�֬d�ߦ�)
select * from Customers
where not exists(
select * from Orders 
where Customers.CustomerID = Orders.CustomerID
)

--4.�ЧQ��in�B��l�t�X�l�d�ߦ��A�d�߭��ǭ��u���B�z�L�q��A
--�æC�X���u�����u�s���B�m�W�B¾�١B�����������X�B�������C
--(���i�Ψ�exists�B��A�礣�i�ΦX�֬d�ߦ�) 
select EmployeeID,FirstName+' '+LastName as '�m�W',Title,Extension,Notes
from Employees
where EmployeeID in(
select EmployeeID 
from Orders
)

--5. �ЦX�֬d�߻P�l�d�ߨ�ؼg�k�A
--�C�X1998�~�שҦ��Q�q�ʹL�����~��ơA�æC�X���~���Ҧ����A�B�̲��~�s���Ѥp��j�ƧǡC
--(�g�X�֬d�߮ɤ��o�Υ���l�d�ߦ��A�g�l�d�߮ɤ��o�Υ���X�֬d�ߦ�)

--5-1�X�֬d��
select distinct pd.*
from Products as pd
inner join [Order Details] as odd on pd.ProductID = odd.ProductID
inner join Orders as od on od.OrderID = odd.OrderID
where od.OrderDate between '1998/01/01' and '1998/12/31'
order by pd.ProductID

--5-2�l�d��
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
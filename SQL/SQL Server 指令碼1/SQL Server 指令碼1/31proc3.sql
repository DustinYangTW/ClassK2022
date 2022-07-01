
select *
from
(select od.ProductID,p.ProductName,year(o.OrderDate) as [Year],month(o.OrderDate) as [Month],
Round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
from [Order Details] as od
inner join Orders as o on od.OrderID = o.OrderID
inner join Products as p on od.ProductID = p.ProductID
where year(o.OrderDate) = 1997
group by od.ProductID,p.ProductName,year(o.OrderDate),month(o.OrderDate)) as x
pivot
(
	sum(x.Total)
	for x.Month in
	([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
)as pvt
order by pvt.ProductID

--寫成活的
alter proc Sum_for_Salse_Pivot
	@yy int
as
begin
declare @in_columns nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+cast(o.Month as varchar)+']','['+cast(o.Month as varchar)+']')
	from 
	(select distinct month(OrderDate) as [Month] from Orders where year(OrderDate)=@yy)as o
	order by [Month]
	print @in_columns
---主查詢的變數處理好了
--
declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+cast(o.Month as varchar)+'],0) as ['+cast(o.Month as varchar)+']'
	from 
	(select distinct month(OrderDate) as [Month] from Orders where year(OrderDate)=@yy) as o
	order by [Month]
	print @select_columns

declare @in_columns_month nvarchar(max)
	select @in_columns_month=isnull(@in_columns_month+',['+cast(o.Month as varchar)+'月]','['+cast(o.Month as varchar)+']')
	from 
	(select distinct month(OrderDate) as [Month] from Orders where year(OrderDate)=@yy)as o
	order by [Month]
	print @in_columns_month

	--'+cast(@yy as varchar)+'
declare @sql nvarchar(max)
set @sql = 
'select pvt.ProductName as 產品名稱'+@select_columns+'
from
(select od.ProductID,p.ProductName,year(o.OrderDate) as [Year],month(o.OrderDate) as [Month],
Round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
from [Order Details] as od
inner join Orders as o on od.OrderID = o.OrderID
inner join Products as p on od.ProductID = p.ProductID
where year(o.OrderDate) = '+cast(@yy as varchar)+'
group by od.ProductID,p.ProductName,year(o.OrderDate),month(o.OrderDate)) as x
pivot
(
	sum(x.Total)
	for '+@in_columns+' in
	('+@in_columns+')
)as pvt
order by pvt.ProductID'

exec(@sql)

end

exec Sum_for_Salse_Pivot 1997

create procedure getOrderDetails
as
begin
	SELECT          教授.教授編號, 班級.課程編號, 員工.薪水
	FROM              教授 INNER JOIN
                            員工 ON 教授.身份證字號 = 員工.身份證字號 INNER JOIN
                            班級 ON 教授.教授編號 = 班級.教授編號 INNER JOIN
                            學生 ON 班級.學號 = 學生.學號 CROSS JOIN
                            客戶業績
end
----------------------------------------
--執行
exec getOrderDetails

create proc deawStar
as
	begin
		declare @i int =1 ,@sum nvarchar(6)='' 
		while @i<5
		begin
		 set @sum += '*'
		 print @sum
		 set @i+=1
		end
end
go
exec deawStar
go

create proc deawStar2
	@c int
as
begin
		declare @i int =1 ,@sum nvarchar(max)='' 
		while @i<=@c
		begin
		 set @sum += '*'
		 print @sum
		 set @i+=1
		end
end

exec deawStar2 10
exec deawStar2 @c = 10

create proc emplyeeDataRow
	@i int ,@j int
as 
begin
	select * 
	from 員工
	order by 身份證字號
	offset 3 rows
	fetch next 2 rows only
end

----exce
exec emplyeeDataRow 2,3
exec emplyeeDataRow @j=2,@i=3 --可以不按照順序

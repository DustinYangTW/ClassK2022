create procedure getOrderDetails
as
begin
	SELECT          �б�.�б½s��, �Z��.�ҵ{�s��, ���u.�~��
	FROM              �б� INNER JOIN
                            ���u ON �б�.�����Ҧr�� = ���u.�����Ҧr�� INNER JOIN
                            �Z�� ON �б�.�б½s�� = �Z��.�б½s�� INNER JOIN
                            �ǥ� ON �Z��.�Ǹ� = �ǥ�.�Ǹ� CROSS JOIN
                            �Ȥ�~�Z
end
----------------------------------------
--����
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
	from ���u
	order by �����Ҧr��
	offset 3 rows
	fetch next 2 rows only
end

----exce
exec emplyeeDataRow 2,3
exec emplyeeDataRow @j=2,@i=3 --�i�H�����Ӷ���

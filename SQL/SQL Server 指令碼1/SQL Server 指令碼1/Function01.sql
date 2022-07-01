create function fnGetdalary(@id char(10))
	returns money
as
begin
	declare @salary money
	select  @salary = 薪水 from 員工
	where 身份證字號 =@id

	if @salary is null
		return '0'

	return @salary
end
go
-------------------------------
declare @Salary money
set @Salary =  dbo.fnGetdalary('A123456789')
if @Salary = 0
	print '查無此人'
else
	print @Salary
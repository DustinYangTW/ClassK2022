create function fnGetdalary(@id char(10))
	returns money
as
begin
	declare @salary money
	select  @salary = �~�� from ���u
	where �����Ҧr�� =@id

	if @salary is null
		return '0'

	return @salary
end
go
-------------------------------
declare @Salary money
set @Salary =  dbo.fnGetdalary('A123456789')
if @Salary = 0
	print '�d�L���H'
else
	print @Salary
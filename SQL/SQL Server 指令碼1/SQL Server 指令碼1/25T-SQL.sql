print 'Hello World'


--�ܼ�
declare @myName varchar(50) = 'Jack'
declare @number int
set @number = 100
print @myName
print @NUMBER

declare @salary money = 50000
print '�A���~����' + cast(@salary as varchar)

declare @birthday datetime = '2022/06-14'
print convert(varchar , @birthday,112)

declare @birthday datetime
select @birthday = �ͤ� from �ǥ� where �Ǹ� = 'S002'
print convert(varchar , @birthday,112)




declare @StuBirthday table (
	name nvarchar(30),
	birthday datetime
)
insert into @StuBirthday values('���ڦ�','2022-6/14')


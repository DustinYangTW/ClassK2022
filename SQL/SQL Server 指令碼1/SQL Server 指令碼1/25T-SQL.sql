print 'Hello World'


--變數
declare @myName varchar(50) = 'Jack'
declare @number int
set @number = 100
print @myName
print @NUMBER

declare @salary money = 50000
print '你的薪水為' + cast(@salary as varchar)

declare @birthday datetime = '2022/06-14'
print convert(varchar , @birthday,112)

declare @birthday datetime
select @birthday = 生日 from 學生 where 學號 = 'S002'
print convert(varchar , @birthday,112)




declare @StuBirthday table (
	name nvarchar(30),
	birthday datetime
)
insert into @StuBirthday values('任我行','2022-6/14')


create function fnOffsetFetchNext(@m int,@n int)
	returns @result table(
		sn int identity,
		id char(10),
		[name] varchar(12),
		salary money
	)
begin
	insert into @result
	select e.身份證字號,e.姓名,e.薪水
	from 員工 as e

			delete from @result where sn<@m or sn>@n
	return

end

select * from dbo.fnOffsetFetchNext(4,6)
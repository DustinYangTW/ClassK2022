create function fnOffsetFetchNext(@m int,@n int)
	returns @result table(
		sn int identity,
		id char(10),
		[name] varchar(12),
		salary money
	)
begin
	insert into @result
	select e.�����Ҧr��,e.�m�W,e.�~��
	from ���u as e

			delete from @result where sn<@m or sn>@n
	return

end

select * from dbo.fnOffsetFetchNext(4,6)
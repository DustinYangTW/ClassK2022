--Instead Trigger

insert into 課程 values('CS349','test',2)

create trigger add_Course_instead on 課程
instead of insert
as
begin
	if exists(select * from 課程 where 課程編號=(select 課程編號 from inserted))
	begin
		update 課程 set 名稱=inserted.名稱,學分=inserted.學分
		from 課程 inner join inserted on 課程.課程編號 = inserted.課程編號
	end
	else
	begin
		insert into 課程 select * from inserted
	end
end
--Instead Trigger

insert into �ҵ{ values('CS349','test',2)

create trigger add_Course_instead on �ҵ{
instead of insert
as
begin
	if exists(select * from �ҵ{ where �ҵ{�s��=(select �ҵ{�s�� from inserted))
	begin
		update �ҵ{ set �W��=inserted.�W��,�Ǥ�=inserted.�Ǥ�
		from �ҵ{ inner join inserted on �ҵ{.�ҵ{�s�� = inserted.�ҵ{�s��
	end
	else
	begin
		insert into �ҵ{ select * from inserted
	end
end
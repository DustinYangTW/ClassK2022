create trigger checkOrderCourse on 班級
after insert
as 
begin
	declare @num int
	select @num = count(*)
	from 班級 where 學號 = (select 學號 from inserted)
	
	if @num >= 5
	begin
		print '您已經選滿5門課程，請先退選後再加選'
		rollback  --一定要寫
	end
end

insert into 班級 values('I002','S001','CS349','2022-07-12','ssss')

select * from 班級
where 學號 ='S001'

--若修改課學分,不得低於原學分數
create trigger checkCredit on 課程
after update
as
begin
	declare @old int,@new int
	select @new=學分 from inserted
	select @old=學分 from deleted

	if @new<@old
	begin
		print '學分數不可低於原學分'
		rollback
	end
end
------------------------------------------
--若刪除員工資料時,該員工也是學生,則不得刪除
select * from 員工
select * from 學生

create trigger checkEmplyoeeIsStudent on 員工
after delete,update
as
begin
	if exists(select * from 學生 where 姓名=(select 姓名 from deleted))
	begin
		rollback
	end
end
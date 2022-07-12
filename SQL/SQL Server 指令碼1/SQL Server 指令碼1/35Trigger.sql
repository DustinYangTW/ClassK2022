select * from 客戶
insert into 客戶 values('C111','王曉明','078888888')

update 客戶
set 姓名='王小小',電話='067777777'
output inserted.客戶編號,inserted.姓名 as NewName,inserted.電話 as NewTel,
deleted.姓名 as oldName,deleted.電話 as oldTel
where 客戶編號 = 'C111'

create trigger showCustomerData on 客戶
after update
as
begin
select inserted.客戶編號,inserted.姓名 as NewName,inserted.電話 as NewTel from inserted

select deleted.姓名 as oldName,deleted.電話 as oldTel from deleted
end


select * from 客戶
update 客戶
set 姓名='王小小',電話='064625811'
where 客戶編號 = 'C012'

select * from 客戶

update 客戶
set 姓名='路人乙',電話='0222885544'
where 客戶編號='C010'
----------------------------------
create trigger showNewCourse on 課程
after insert
as
begin
	select * from inserted
end
-----------------------------
insert into 課程 values('CS879','test',3)
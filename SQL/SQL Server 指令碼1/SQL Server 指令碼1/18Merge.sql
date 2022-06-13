merge 客戶 as c
using 新客戶 as nc
on c.客戶編號=nc.客戶編號
when matched then 
	update set 姓名=nc.姓名,電話=nc.電話
when not matched then 
	insert (客戶編號,姓名,電話) values(nc.客戶編號,nc.姓名,nc.電話);


merge 客戶業績 as cs
using 客戶 as c
on c.客戶編號=cs.客戶編號
when matched and cs.業績目標 >=250 then
	delete
when matched then
	update set 業績目標 = cs.業績目標+25
when not matched then 
	insert(客戶編號,業績目標) values(c.客戶編號,100);
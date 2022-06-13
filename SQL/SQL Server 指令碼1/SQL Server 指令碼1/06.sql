--合併資料
--inner join 
select c.學號,a.姓名,co.課程編號
--班級.* ->班級裡面的學生資料
--可以用別名取代 變成 c.*
from 班級 as c 
inner join 學生 as a on c.學號 = a.學號 --外來鍵連接
inner join 課程 as co on co.課程編號= co.課程編號 --外來鍵連接


-------------------------------------------------------
--inner join 的第二種寫法

select s.學號,s.姓名, s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 員工 as e 
inner join (教授 as p inner join 
(課程 as co inner join 
(班級 as c inner join 學生 as s on c.學號=s.學號) 
on c.課程編號=co.課程編號) 
on p.教授編號=c.教授編號) 
on e.身份證字號=p.身份證字號
---------------------------------------
--第三種寫法(自然(隱含)合併法)

select s.學號,s.姓名, s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 班級 as c ,學生 as s, 課程 as  co,教授 as p,員工 as e 
where  c.學號=s.學號 and c.課程編號=co.課程編號 
and c.教授編號=p.教授編號 and e.身份證字號=p.身份證字號
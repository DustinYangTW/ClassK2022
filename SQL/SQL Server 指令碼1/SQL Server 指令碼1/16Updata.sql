update 課程2
set 學分 = 2 
where 課程編號 = 'CS222'

--若選課人數>=3，將課程學分數改為30
update 課程2
set 學分 = 30 
where 課程編號 in (
select 課程編號
from 班級
group by 課程編號
having COUNT(*)>=3
)

select 課程編號,COUNT(*)
from 班級
group by 課程編號
having COUNT(*)>=3


--把有被選課的課程,將課程學分數改為100
update 課程2
set 學分=100
from 班級 as c inner join 課程2 as co
on c.課程編號=co.課程編號

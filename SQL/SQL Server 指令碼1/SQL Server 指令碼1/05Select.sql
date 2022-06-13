







select 性別,count(*) as 學生人數
from 學生
group by 性別

select 學號,count(*) as 選課數
from 班級
group by 學號

select 教授編號,count(*) as 老師被選數
from 班級
group by 教授編號

select 教授編號,課程編號,count(*) as 老師被選數
from 班級
group by 教授編號,課程編號


--having(跟where功能一樣)
select 學號,Count(*) as 選課數
from 班級
--where COUNT(*) <3
group by 學號
having Count(*) <3
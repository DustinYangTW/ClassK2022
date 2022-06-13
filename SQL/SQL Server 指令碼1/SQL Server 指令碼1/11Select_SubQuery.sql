select *
from 班級
where 學號='S003'
select *
from 學生
where 姓名='張無忌'

--原本要上面的
--後面可以用下面的
select *
from 班級
where 學號=(
select 學號
from 學生
where 姓名='張無忌'
)

select *
from 員工
where 薪水 > (
select AVG(薪水) 
from 員工
)

select a.身份證字號,a.姓名,a.薪水
from 員工 as a
left join 員工 as s on a.身份證字號 != s.身份證字號  --利用不等於來做比較
group by a.身份證字號,a.姓名,a.薪水
having a.薪水 > AVG(s.薪水)

select e.身份證字號,e.姓名,e.薪水
from 員工 as e ,員工 as s
group by e.身份證字號,e.姓名,e.薪水
having e.薪水 > AVG(s.薪水)

select *
from 員工 
where 身份證字號 in (
select 身份證字號
from 教授
where 職稱 = '教授'
)

select *
from 員工 
where 身份證字號 = (
select 身份證字號
from 教授
where 職稱 = '教授'
)

select *
from 教授
select *
from 員工

select * from 員工
where exists (
select * 
from 教授 
where 員工.身份證字號 = 教授.身份證字號 --過濾器
)

--exists
select * from 學生
where exists (select * from 班級
where 課程編號='CS222' and 學生.學號=班級.學號)

--in
select * from 學生
where 學號 in (select 學號 from 班級
where 課程編號='CS222')

select * 
from 課程
select * 
from 班級
--哪些課程在221-S教室上課
--in
select *
from 課程
where 課程編號 in(
select 課程編號
from 班級
where 教室 = '221-S'
)

--exists
select *
from 課程
where exists(
select *
from 班級
where 教室 = '221-S' and 課程.課程編號 = 班級.課程編號
)

select * 
from 課程
select * 
from 學生
select * 
from 班級
select * 
from 課程
--in
select * from 課程
where 課程編號 in(
select 課程編號 from 班級 where 學號 = (
select 學號 from 學生 where 姓名 = '周杰輪')
)
--exists
select * from 課程 as co
where exists
(select * from 班級 as c
where exists(
select * from 學生 as s where 姓名='周杰輪' and c.學號=s.學號 and co.課程編號=c.課程編號))

--查詢學生周杰輪沒有選的課程資料
--子查詢

--in
select * from 課程
where 課程編號 not in(
select 課程編號 from 班級 where 學號 = (
select 學號 from 學生 where 姓名 = '周杰輪')
)
--exists
select * from 課程 as co
where not exists
(select * from 班級 as c
where exists(
select * from 學生 as s where 姓名='周杰輪' and c.學號 =s.學號 and co.課程編號=c.課程編號))


select * from 員工
where 薪水 >= all( --所有條件都要滿足
select 薪水 from 員工
where 城市 ='台北')

select * from 員工
where 薪水 >= some( --有條件都要滿足就好
select 薪水 from 員工
where 城市 ='台北')

select * from 員工
where 薪水 >= any( --有條件都要滿足就好
select 薪水 from 員工
where 城市 ='台北')
--篩選條
select *
from 學生
where 性別 = '男'

select *
from 員工
where 薪水 >= 50000

select *
from 學生
where 生日 Is Null

--like(模糊查詢)
-- % (代表0~n任意字元)
-- _(表示1個任意字元)

select *
from 教授
where 科系 like 'cs'

select * 
from 教授
where 科系 like '%[cklj]%'


select * 
from 教授
where 科系 like '%[A-DW-Z0-5]%'

--between .. and ..運算
select * 
from 員工
where 薪水 between 25000 and 55000 --也可以寫薪水>=2500 and 薪水 <=55000
--in
select *
from 課程
where 課程編號 = 'CS101' or 課程編號 = 'CS213' or 課程編號 = 'CS349' or 課程編號 = 'CS999'

select *
from 課程
where 課程編號 in( 'CS101' , 'CS213' , 'CS349','CS999')

--聚合函數
--count()
select count(*) as 學生總數
from 學生
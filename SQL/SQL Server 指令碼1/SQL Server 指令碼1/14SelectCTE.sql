--CTE

with test
as(
select p.* from  教授 as p inner join 員工 as e 
on p.身份證字號 = e.身份證字號
)

select * from test

with 主管階層
as(
select 姓名,1 as 層級,員工字號 from 主管 where 主管字號 is null
union all --取聯集，重複排除掉
select 主管.姓名,層級+1 as 層級,主管.員工字號 from 主管 inner join 主管階層
on 主管.主管字號 =  主管階層.員工字號
)
select 主管階層.姓名,主管階層.層級
from 主管階層
order by 主管階層.層級
--offset
select *
from 員工
order by 身份證字號

select *
from 員工
order by 身份證字號
offset 3 rows

select *
from 員工
order by 身份證字號
offset 3 rows
fetch next 2 rows only

select * from 班級 as c 
inner join 學生 as s on c.學號 = s.學號
inner join 課程 as co on c.課程編號 = co.課程編號

select *
from (select 學號,課程編號,教室 from 班級) as x
pivot
(
	max(教室)
	for 課程編號 in
	([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])
)as pvt

--進化
select 學號,isnull([CS101],'---') as CS101,isnull([CS349],'---') as CS349,
isnull([CS222],'---') as CS222,isnull([CS203],'---') as CS203,
isnull([CS111],'---') as CS111,isnull([CS121],'---') as CS121,
isnull([CS205],'---') as CS205
from (select 學號,課程編號,教室 from 班級) as x
pivot
(
	max(教室)
	for 課程編號 in
	([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])
)as pvt


Create proc getCoursePivot
as
begin

	declare @in_columns nvarchar(max)
	declare @sql nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+課程編號+']','['+課程編號+']')
	from 
	(select 課程編號 from 課程) as a
	print @in_columns

	declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+課程編號+'],''---'') as ['+課程編號+']'
	from 
	(select 課程編號 from 課程) as b
	order by 課程編號
	print @select_columns

	set @sql=
	'select 學號'+@select_columns+'
	from (select 學號,課程編號,教室 from 班級) as x
	pivot
	(
		max(教室)
		for 課程編號 in
		('+@in_columns+' )
	) as pvt'

	exec(@sql)
end

exec getCoursePivot

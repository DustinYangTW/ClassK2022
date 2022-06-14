

select 姓名,
	case 性別
		when '男' then '先生'
		when '女' then '小姐'
		else 'N/A'
	end
from 學生
go

declare @gerder nvarchar(1),@result nvarchar(6)
set @gerder='1'
set @result = 
	case
		when @gerder='1' then '先生'
		when @gerder='0' then '小姐'
		else 'N/A'
	end
print @result
go

declare @height int,@result nvarchar(6)
set @height = 150
set @result =
		case
		when @height>'123' then '全票'
		when @height>'90' then '半票'
		else '免費'
	end
print @result
go


select �m�W,
	case �ʧO
		when '�k' then '����'
		when '�k' then '�p�j'
		else 'N/A'
	end
from �ǥ�
go

declare @gerder nvarchar(1),@result nvarchar(6)
set @gerder='1'
set @result = 
	case
		when @gerder='1' then '����'
		when @gerder='0' then '�p�j'
		else 'N/A'
	end
print @result
go

declare @height int,@result nvarchar(6)
set @height = 150
set @result =
		case
		when @height>'123' then '����'
		when @height>'90' then '�b��'
		else '�K�O'
	end
print @result
go
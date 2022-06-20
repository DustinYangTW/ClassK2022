declare @number int = 3 ,@number2 int =0

begin try
	print @number/@number2
end try
begin catch
	print @@error
end catch
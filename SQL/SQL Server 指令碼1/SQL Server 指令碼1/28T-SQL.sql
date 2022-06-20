declare @i int =1 ,@sum nvarchar(6)='' 
while @i<5
begin
 set @sum += '*'
 print @sum
 set @i+=1
end
print @sum
print @i
create procedure getOrderDetails
as
begin
	SELECT          教授.教授編號, 班級.課程編號, 員工.薪水
	FROM              教授 INNER JOIN
                            員工 ON 教授.身份證字號 = 員工.身份證字號 INNER JOIN
                            班級 ON 教授.教授編號 = 班級.教授編號 INNER JOIN
                            學生 ON 班級.學號 = 學生.學號 CROSS JOIN
                            客戶業績
end
----------------------------------------
--執行
exec getOrderDetails
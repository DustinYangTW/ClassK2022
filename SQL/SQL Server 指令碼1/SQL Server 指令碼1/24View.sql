create view viewStudentCourseDetail
as
SELECT    *      
FROM              dbo.員工 INNER JOIN
                            dbo.教授 ON dbo.員工.身份證字號 = dbo.教授.身份證字號 INNER JOIN
                            dbo.班級 ON dbo.教授.教授編號 = dbo.班級.教授編號 INNER JOIN
                            dbo.課程 ON dbo.班級.課程編號 = dbo.課程.課程編號 INNER JOIN
                            dbo.學生 ON dbo.班級.學號 = dbo.學生.學號

select 學號,Expr5,count(*) from View_1
group by 學號,Expr5
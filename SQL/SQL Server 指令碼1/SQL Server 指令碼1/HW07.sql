--1.
create database HW7
go

--2.
use HW7
go
create table 學生資料表(
	學號 char(10) primary key,
	姓名 nvarchar(20) not null ,
	電話 varchar(20) not null ,
	地址 nvarchar(100) not null ,
	生日 datetime
)

drop table 學生資料表

--3.

use HW7
go
create table 課程資料表(
	課程代碼 char(6) primary key,
	課程名稱 nvarchar(30) not null ,
	學分數 int not null default 3
)


--4.
use HW7
go
create table 訂單資料表(
	訂單代號 char(10) primary key,
	訂購日期 datetime not null
)

create table 產品資料表(
	產品編號 char(6) primary key,
    產品名稱 nvarchar(50) not null
)

create table 訂單明細(
	訂單代號 char(10),
	產品編號 char(6),
	購買數量 int not null,
	primary key(訂單代號,產品編號),
	foreign key(訂單代號) references 訂單資料表(訂單代號) on delete no action on update no action,
	foreign key(產品編號) references 產品資料表(產品編號) on delete no action on update cascade
)
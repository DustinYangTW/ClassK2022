--1.
create database HW7
go

--2.
use HW7
go
create table �ǥ͸�ƪ�(
	�Ǹ� char(10) primary key,
	�m�W nvarchar(20) not null ,
	�q�� varchar(20) not null ,
	�a�} nvarchar(100) not null ,
	�ͤ� datetime
)

drop table �ǥ͸�ƪ�

--3.

use HW7
go
create table �ҵ{��ƪ�(
	�ҵ{�N�X char(6) primary key,
	�ҵ{�W�� nvarchar(30) not null ,
	�Ǥ��� int not null default 3
)


--4.
use HW7
go
create table �q���ƪ�(
	�q��N�� char(10) primary key,
	�q�ʤ�� datetime not null
)

create table ���~��ƪ�(
	���~�s�� char(6) primary key,
    ���~�W�� nvarchar(50) not null
)

create table �q�����(
	�q��N�� char(10),
	���~�s�� char(6),
	�ʶR�ƶq int not null,
	primary key(�q��N��,���~�s��),
	foreign key(�q��N��) references �q���ƪ�(�q��N��) on delete no action on update no action,
	foreign key(���~�s��) references ���~��ƪ�(���~�s��) on delete no action on update cascade
)
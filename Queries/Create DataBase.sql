use master
go

if db_id ('BelaSport') is not null
begin
	drop database BelaSport
end
go

create database BelaSport
go

use BelaSport
go

create table eventType
(
	eventTypeId int identity(1,1) not null,
	name_eventType varchar(50) not null,
	constraint pk_eventType primary key (eventTypeId)
)
go

create table host
(
	dniHost int not null,
	nameHost varchar(50) not null,
	lastNameHost varchar(50) not null,
	constraint pk_host primary key (dniHost)
)
go

create table eventTitle
(
	eventId int identity(1,1) not null,
	name_event varchar(50) not null,
	dniHost int not null,
	eventTypeId int not null,
	constraint pk_eventtitle primary key (eventId)
)
go

alter table eventTitle add constraint fk_eventTitle_eventType
	foreign key (eventTypeId) references eventType (eventTypeId) 
	on delete no action on update no action
go

alter table eventTitle add constraint fk_eventTitle_host
	foreign key (dniHost) references host (dniHost)
	on delete no action on update no action
go

insert into eventType (name_eventType) values('Social')
insert into eventType (name_eventType) values('Sport')
go

insert into host (dniHost,nameHost,lastNameHost) values(70350346,'Carlos','Noel')
insert into host (dniHost,nameHost,lastNameHost) values(75642155,'Mary Allen','Potter')
go
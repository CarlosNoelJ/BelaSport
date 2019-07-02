use BelaSport
go

if OBJECT_ID ('sp_list_eventType') is not null
begin
	drop procedure sp_list_eventType
end
go
create procedure sp_list_eventType
as
	select * from eventType
go

if OBJECT_ID ('sp_list_host') is not null
begin
	drop procedure sp_list_host
end
go
create procedure sp_list_host
as
	select * from host
go

if OBJECT_ID ('sp_list_eventTitle') is not null
begin
	drop procedure sp_list_eventTitle
end
go
create procedure sp_list_eventTitle
as
	select * from eventTitle
go

if OBJECT_ID ('sp_insert_evenType') is not null
begin
	drop procedure sp_insert_evenType
end
go
create procedure sp_insert_evenType (@name_eventType varchar(50))
as
	insert into eventType (name_eventType) values(@name_eventType)
go

if OBJECT_ID ('sp_insert_host') is not null
begin
	drop procedure sp_insert_host 
end
go
create procedure sp_insert_host (@dniHost int, @nameHost varchar(50))
as
	insert into host (dniHost,nameHost) values(@dniHost,@nameHost)
go

if OBJECT_ID ('sp_insert_eventTitle') is not null
begin
	drop procedure sp_insert_eventTitle
end
go
create procedure sp_insert_eventTitle (@name_event varchar(50), @dniHost int, @evenTypeId int)
as
	insert into eventTitle (name_event, dniHost, eventTypeId) values(@name_event,@dniHost,@evenTypeId)
go


if OBJECT_ID ('sp_update_name_eventTitle') is not null
begin
	drop procedure sp_update_name_eventTitle
end
go
create procedure sp_update_name_eventTitle (@eventId int,@name_event varchar(50))
as
	update eventTitle set name_event = @name_event where eventId = @eventId
go

if OBJECT_ID ('sp_update_fullName_host') is not null
begin
	drop procedure sp_update_fullName_host
end
go
create procedure sp_update_fullName_host (@dniHost int, @nameHost varchar(50), @lastNameHost varchar(50))
as
	update host set nameHost = @nameHost, lastNameHost = @lastNameHost where dniHost = @dniHost
go


drop table ScheduleApp

create table ScheduleApp
(
PatientID int,
Specialization varchar(20),
Doctor varchar(20),
VisitDate varchar(20),
AppointmentTime varchar(20)
)

go
create proc Doctor
@fname varchar(20),
@lname varchar(20),
@sex varchar(20),
@sp varchar(20),
@vh varchar(20)
as
insert AddDoctor values(@fname,@lname,@sex,@sp,@vh)


go
create proc Patient
@fname varchar(20),
@lname varchar(20),
@sex varchar(20),
@age int,
@dob varchar(20)
as
insert AddPatient values(@fname,@lname,@sex,@age,@dob)


go
create proc Sche
@id int,
@sp varchar(20),
@Doc varchar(20),
@vd varchar(20),
@app varchar(20)
as
insert ScheduleApp values(@id,@sp,@Doc,@vd,@app)
drop proc Sche
create table usertable
(
Username varchar(20),
FirstName varchar(20),
LastName varchar(20),
Password varchar(20)
)

insert usertable values('Anand','An','Kum','Anraj')
go
create proc usertab
@un varchar(20),
@ps varchar(20)
as
select * from usertable where Username like @un and Password like @ps

select * from AddDoctor
select * from AddPatient
select * from ScheduleApp

create proc cancelapp
@patientid varchar(20)
as
delete ScheduleApp where PatientID=@patientid

create proc Selectee
as
select * from ScheduleApp

drop table ScheduleApp

delete from AddDoctor where DoctorID=5
delete from AddDoctor where DoctorID=4
delete from AddDoctor where DoctorID=3
delete from AddDoctor where DoctorID=2

create proc Displaydoc
as
select 
DoctorID,FirstName,LastName,Sex,Specialization,VisitingHours
from AddDoctor

truncate table AddDoctor
truncate table AddPatient
truncate table ScheduleApp
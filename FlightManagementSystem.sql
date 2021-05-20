create database FlightManagementSystem

use FlightManagementSystem

create table Userdetails(
userid int identity(1,1) primary key,
username varchar(50),
email varchar(100),
phone varchar(25),
age int,
password varchar(15)
)

insert into Userdetails values('Manali','mannu@gmail.com','81384400494',23,'aaa')

select * from Userdetails

create table Airlines(
airlinesid int identity(101,1) primary key,
airlinename varchar(50),
email varchar(50),
password varchar(50)
)

insert into Airlines values('Indigo','indigo@gmail.com','aaa');

select * from Airlines


create table Flights(
flightid int identity(201,1) primary key,
airlineid int foreign key references Airlines(airlinesid),
FromLocation varchar(50),
ToLocation varchar(50),
Duration int,
date datetime,
AvailableSeats int,
Price decimal,
ArrivalTime varchar(50),
DepartureTime varchar(50)
)


insert into Flights values(101,'Chennai','Bangalore',2,'12-10-2020',50,5450,'5:00 AM','3:00 AM');
insert into Flights values(101,'Delhi','Bangalore',2,'12-10-2020',50,6450,'5:00 AM','3:00 AM');

delete from Flights where flightid in (203,204)


select * from Flights

create table Bookings(
bookingid int identity(301,1) primary key,
userid int foreign key references Userdetails(userid),
flightid int foreign key references Flights(flightid),
no_of_seats int,
totalprice decimal
)

select * from Bookings

delete from Bookings where bookingid in (302,305,306,307,308,309,310)



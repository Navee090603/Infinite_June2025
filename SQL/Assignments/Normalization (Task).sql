
-----1NF
use assignment

create table clientrental (
  clientno varchar(10),
  cname varchar(100),
  propertyno varchar(10),
  paddress varchar(200),
  rentstart date,
  rentfinish date,
  rent decimal(10, 2),
  ownerno varchar(10),
  oname varchar(100))



insert into clientrental  values('cr76', 'john kay', 'pg4', '6 lawrence st, glasgow', '2001-10-01', '2001-08-31', 350, 'co40', 'tina murphy'),
('cr76', 'john kay', 'pg16', '5 novar dr, glasgow', '2002-09-01', '2002-09-01', 450, 'co93', 'tony shaw'),
('cr76', 'john kay', 'pg4', '6 lawrence st, glasgow', '1999-09-01', '2000-06-10', 350, 'co40', 'tina murphy'),
('cr56', 'aline stewart', 'pg36', '2 manor rd, glasgow', '2000-10-10', '2001-12-01', 370, 'co93', 'tony shaw'),
('cr56', 'aline stewart', 'pg16', '5 novar dr, glasgow', '2002-11-01', '2003-08-01', 450, 'co93', 'tony shaw')

select * from clientrental

--------------------2NF

-- client table
create table client (clientno varchar(10) primary key,
 cname varchar(100))

insert into client  values('cr76', 'john kay'),
('cr56', 'aline stewart')

select * from client

-- propertydetails table
create table propertydetails (
  propertyno varchar(10) primary key,
  paddress varchar(200),
  rent decimal(10,2),
  ownerno varchar(10))

insert into propertydetails values('pg4', '6 lawrence st, glasgow', 350, 'co40'),
('pg16', '5 novar dr, glasgow', 450, 'co93'),
('pg36', '2 manor rd, glasgow', 370, 'co93')

select * from propertydetails

-- clientrental table
create table clientrental2nf (
  clientno varchar(10),
  propertyno varchar(10),
  rentstart date,
  rentfinish date,
  primary key (clientno, propertyno, rentstart),
  foreign key (clientno) references client(clientno),
  foreign key (propertyno) references propertydetails(propertyno))

insert into clientrental2nf values ('cr76', 'pg4', '2001-10-01', '2001-08-31'),
('cr76', 'pg16', '2002-09-01', '2002-09-01'),
('cr76', 'pg4', '1999-09-01', '2000-06-10'),
('cr56', 'pg36', '2000-10-10', '2001-12-01'),
('cr56', 'pg16', '2002-11-01', '2003-08-01')

select * from clientrental2nf

---------------------------3NF

-- owner table
create table owner (ownerno varchar(10) primary key,
  oname varchar(100))

insert into owner values('co40', 'tina murphy'),
('co93', 'tony shaw')

select * from owner

-- updated propertydetails table with foreign key
create table propertydetails3nf (
  propertyno varchar(10) primary key,
  paddress varchar(200),
  rent decimal(10,2),
  ownerno varchar(10),
  foreign key (ownerno) references owner(ownerno))

insert into propertydetails3nf values('pg4', '6 lawrence st, glasgow', 350, 'co40'),
('pg16', '5 novar dr, glasgow', 450, 'co93'),
('pg36', '2 manor rd, glasgow', 370, 'co93')

select * from propertydetails3nf
----------------------------

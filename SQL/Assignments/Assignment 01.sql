--Assignment 1


--TABLE CLIENTS 

--Create

create table Clients(
Client_ID numeric(4) primary key,
Cname varchar(40)not null,
Address varchar(30),
Email varchar(30)unique,
Phone numeric(10),
Bussiness varchar(20)not null)

--Insert

insert into clients values (1001, 'acme utilities', 'noida', 'contact@acmeutil.com', 9567880032, 'manufacturing'),
(1002, 'trackon consultants', 'mumbai', 'consult@trackon.com', 8734210090, 'consultant'),
(1003, 'moneysaver distributors', 'kolkata', 'save@moneysaver.com', 7799886655, 'reseller'),
(1004, 'lawful corp', 'chennai', 'justice@lawful.com', 9210342219, 'professional')




--TABLE EMPLOYEE

--Create 

create table employee(
Empno numeric(4) primary key,
Ename varchar(20)not null,
Job varchar(15),
Salary numeric(7)check (salary>0),
Deptno numeric(2),
foreign key (deptno) references Departments(deptno))

--insert
insert into employee values(7001, 'sandeep', 'analyst', 25000, 10),
(7002, 'rajesh', 'designer', 30000, 10),
(7003, 'madhav', 'developer', 40000, 20),
(7004, 'manoj', 'developer', 40000, 20),
(7005, 'abhay', 'designer', 35000, 10),
(7006, 'uma', 'tester', 30000, 30),
(7007, 'gita', 'tech. writer', 30000, 40),
(7008, 'priya', 'tester', 35000, 30),
(7009, 'nutan', 'developer', 45000, 20),
(7010, 'smita', 'analyst', 20000, 10),
(7011, 'anand', 'project mgr', 65000, 10)



--TABLE DEPARTMENTS

-- create 
create table departments (
deptno numeric(2) primary key,
dname varchar(15) not null,
loc varchar(20)
)

-- insert 
insert into departments values (10, 'design', 'pune'),
(20, 'development', 'pune'),
(30, 'testing', 'mumbai'),
(40, 'document', 'mumbai')




--TABLE PROJECTS

--create

Create table Projects (
Project_ID int primary key,
Descr varchar(30) not null,
Start_Date Date, 
Planned_End_Date Date, 
Actual_End_Date Date,
Budget bigint check (Budget > 0),
Client_ID numeric(4) references Clients(Client_ID),
Constraint Check_Actual_End_Date check (Actual_End_Date > Planned_End_Date))

--insert

insert into projects values (401, 'inventory', '2011-04-01', '2011-10-01',  '2011-10-31', 150000, 1001),
(402, 'accounting', '2011-08-01', '2012-01-01', null, 500000, 1002),
(403, 'payroll',  '2011-10-01', '2011-12-31', null, 75000, 1003),
(404, 'contact mgmt',  '2011-11-01',  '2011-12-31', null, 50000, 1004)






--TABLE EmpProjectTasks 

--create

create table EmpProjectTasks(
Project_ID int,
Empno numeric(4),
Start_Date date,
End_Date date,
Task varchar(25)not null,
Status varchar(15)not null,
constraint pk primary key (Project_Id,Empno),
constraint fk_Pro foreign key(Project_ID) references projects(Project_ID),
constraint fk_Emp foreign key(Empno) references Employee(empno))


--insert

insert into empprojecttasks values(401, 7001, '2011-04-01', '2011-04-20', 'system analysis', 'completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'system design', 'completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'coding', 'completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'coding', 'completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'testing', 'completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'code change', 'completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'testing', 'completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'documentation', 'completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'sign off', 'completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'system analysis', 'completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'system design', 'completed'),
(402, 7004, '2011-10-01', null, 'coding', 'in progress')


--select

select * from clients    --1
select * from employee   --2
select * from departments--3
select * from projects   --4
select * from empprojecttasks --5


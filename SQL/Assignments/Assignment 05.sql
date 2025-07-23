--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details

create or alter proc sp_payslip(@empno int)


as
begin
    declare @ename varchar(30)
    declare @salary float
    declare @hra float
    declare @da float
    declare @pf float
    declare @it float
    declare @ded float
    declare @gross float
    declare @net float
select @ename=ename,@salary=salary from emp where empno=@empno

if @ename IS NULL
begin
print 'Employee not found.'
return
end

set @hra=@salary*0.10
set @da=@salary*0.20
set @pf=@salary*0.08
set @it=@salary*0.05
set @ded=@pf+@it
set @gross=@salary+@hra+@da
set @net=@gross-@ded

print '------Pay Slip------'
print 'Employee Number: ' + cast(@empno as varchar(10))
print 'Employee Name  : ' + @ename
print 'Basic Salary   : ' + cast(@salary as varchar(10))
print 'HRA (10%)      : ' + cast(@Hra as varchar(10))
print 'DA  (20%)	   : ' + cast(@DA as varchar(10))
print 'PF  (8%)	   : ' + cast(@pf as varchar(10))
print 'IT  (5%)       : ' + cast(@it as varchar(10))
print 'DED    	       : ' + cast(@DED as varchar(10))
print 'Gross Salary   : ' + cast(@gross as varchar(10))
print 'Net Salary	   : ' + cast(@net as varchar(10))

end

select * from emp

exec sp_payslip 7369
exec sp_payslip 7490

--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 


create or alter trigger trg_On_Holiday
on emp for insert,delete,update 
as
begin
declare @hname varchar(20)
select @hname=holiday_name from holiday where Holiday_date=cast(getdate() as date)

if @hname is not null
begin
raiserror('Due to %s,you cannot manipulate data',16,1,@hname)
rollback
end
end














--creation of Holiday Table
create table Holiday(Holiday_Date Date,Holiday_Name varchar(20))

insert into holiday values
('2025-01-26', 'Republic Day'),
('2025-08-15', 'Independence Day'),
('2025-10-20', 'Diwali'),
('2025-12-25', 'Christmas')

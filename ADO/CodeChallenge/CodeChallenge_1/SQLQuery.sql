create table employee_details (Empid int identity(1,1) primary key,
    Name varchar(50),
    Salary float,
    Netsalary float,
    Gender varchar(10))

select * from employee_details
select Empid,Name,Salary,Gender from employee_details

--procedure

create or alter procedure sp_insertemployeedetails
    @name varchar(50),
    @salary float,
    @gender varchar(10),
    @generatedempid int output,
    @netsalary float output
as
begin
    set nocount on
    set @netsalary = @salary * 0.9; -- net salary after 10% deduction

    insert into employee_details (name, salary, netsalary, gender)
    values (@name, @salary, @netsalary, @gender);

    set @generatedempid = scope_identity(); -- returns the last generated identity value
end

--Example



declare @empid int, @netsal float
exec sp_insertemployeedetails 'Naveen', 50000, 'Male', @empid output, @netsal output
print 'empid : ' + cast(@empid as varchar)
print 'net salary : ' + cast(@netsal as varchar)

--update_procedure

create or alter procedure sp_updateempsalary
    @empid int,
    @updatedsalary float output
as
begin
    update employee_details
    set salary = salary + 100
    where empid = @empid

    select @updatedsalary = salary
    from employee_details
    where empid = @empid
end



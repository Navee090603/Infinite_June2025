




--1.	Write a query to display your birthday( day of week)
 
select datename(weekday, cast('2003-06-09' as date)) as Birthday





--2.	Write a query to display your age in days

select datediff(day, '2003-06-09', getdate()) as Age_In_Days




 
--3.	Write a query to display all employees information those who joined before 5 years in the current month
 
--(Hint : If required update some HireDates in your EMP table of the assignment)

update emp
set hire_date='15-jul-18'
where ename in ('allen','smith')

select * from emp where month(hire_date) = month(getdate()) and datediff(year, hire_date, getdate()) >= 5

select * from emp







 
--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--        c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.


begin transaction
insert into emp values (3801, 'Messi', 'Football', 7902, '01-jan-22', 1000, 1000, 20),  -- Insert
                      (3802, 'Neymer', 'salesman', 7698, '01-feb-23', 1000, 200, 30),
                      (3803, 'Ronaldo', 'analyst', 7566, '01-mar-19', 2500, null, 20)
update emp set salary = salary + salary * 0.15 where empno = 3802						-- Update second row
save tran before_delete
delete from emp where empno = 3801  -- Delete first row
rollback tran before_delete
commit transaction

select * from emp
 





--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
--	a.     For Deptno 10 employees 15% of sal as bonus.
--	b.     For Deptno 20 employees  20% of sal as bonus
--	c      For Others employees 5%of sal as bonus



create or alter function fn_calculate_bonus(@deptno int)
returns table
as
return (select empno, ename, salary, deptno,
        case 
            when deptno = 10 then salary * 0.15
            when deptno = 20 then salary * 0.20
            else salary * 0.05
        end as Bonus from emp where deptno = @deptno)
 
 select * from dbo.fn_calculate_bonus(10)
 select * from dbo.fn_calculate_bonus(20)
 select * from dbo.fn_calculate_bonus(30)



  select * from emp where deptno=10
  select * from emp where deptno=20
  select * from emp where deptno=30


--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create or alter procedure update_sales
as
begin
  update e set e.salary = e.salary + 500 from emp e join dept d on e.deptno = d.deptno where d.dname = 'sales' and e.salary < 1500
end

exec update_sales

select * from emp

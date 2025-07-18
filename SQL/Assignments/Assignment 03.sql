use assignment

---Assignment 2

--1. Retrieve a list of MANAGERS. 

select distinct e1.mgr_id Managaer_Id,e2.ename Manager_Name 
from emp e1 
join emp e2 on e1.mgr_id=e2.empno



--2. Find out the names and salaries of all employees earning more than 1000 per month. 

select ename Emp_Name,Salary Monthly_Salary 
from emp 
where salary>1000



--3. Display the names and salaries of all employees except JAMES. 

select ename Employee_Name,salary Salary 
from emp 
where ename != 'james'



--4. Find out the details of employees whose names begin with ‘S’. 

select ename Employee_Name 
from emp 
where ename like 's%'


--5. Find out the names of all employees that have ‘A’ anywhere in their name. 

select ename Employee_Name 
from emp 
where ename like '%a%'


--6. Find out the names of all employees that have ‘L’ as their third character in their name. 

select ename Employee_Name 
from emp 
where ename like '__[l]%'


--7. Compute daily salary of JONES. 

select ename Employee_Name,salary/30 Salary 
from emp 
where ename='jones'


--8. Calculate the total monthly salary of all employees.

select sum(salary) Total_Salary from emp


--9. Print the average annual salary . 

select avg(salary * 12) Average_Annual_Salary from emp 



--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 

select ename Emp_Name, job, deptno 
from emp 
where not (job = 'salesman' and deptno = 30)



--11. List unique departments of the EMP table.

select distinct d.dname Department 
from emp 
join dept d on emp.deptno=d.deptno



--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.

select ename Employee,salary Monthly_Salary,deptno 
from emp 
where salary>1500 and (deptno=10 or deptno=30)



--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select ename,job,salary 
from emp 
where (job='manager' or job='analyst') AND salary NOT IN (1000, 3000, 5000)



--14. Display the name, salary and commission for all employees whose commission  amount is greater than their salary increased by 10%. 

select ename Emp_Name,Job,comm as commision 
from emp 
where comm>salary*1.10



--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 

select ename,deptno,mgr_id as Employee_Name 
from emp 
where ename like '%l%l%' and (deptno=30 or mgr_id=7782)



--16. Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. 

select ename Employee 
from emp 
where Datediff(year,hire_date,GETDATE()) between 31 and 39
--count
select count(ename) Count_of_employee 
from emp 
where Datediff(year,hire_date,GETDATE()) between 31 and 39



--17. Retrieve the names of departments in ascending order and their employees in descending order.

select d.dname Department_Name,e.ename Employee_Name 
from emp e 
join dept d on e.deptno=d.deptno 
order by d.dname asc,e.ename desc



--18. Find out experience of MILLER. 

select ename Employee_Name,DATEDIFF(year,hire_date,getdate()) as Experience 
from emp where ename='miller'
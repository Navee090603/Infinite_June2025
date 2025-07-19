use assignment

--Assignment 4


--query 1 Write a T-SQL Program to find the factorial of a given number.

declare @num int=3
declare @out int =1,@j int=2
while @j<=@num
begin
	set @out*=@j
	set @j+=1
end
print 'Factorial of ' + cast (@num as varchar) + ' is : ' + cast(@out as varchar)

--query 2 Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter proc sp_Multi @num int
as
begin
declare @i int=1,@out int
while @i<=@num
begin
	set @out=@num*@i
	print cast(@num as varchar) + ' * ' + cast(@i as varchar)+ ' = '+cast(@out as varchar)
	set @i+=1
end
end

exec sp_Multi 5

--query 3 Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly.

create or alter function fn_C(@score int)
returns varchar(4)
as
begin
declare @status varchar(4)
set @status=case when @score>=50 then 'Pass' else 'Fail' end
return @status
end

select s.sname Student_Name,m.Score,dbo.fn_C(m.Score) Status from marks m join student s on m.sid=s.sid

--creation of table for third question

--student
create table student(sid int primary key identity,
sname varchar(15))

insert into student values ('Jack'),('Rithvik'),('Jaspreeth'),('Praveen'),('Bisa'),('Suraj')

--marks
create table Marks(mid int primary key identity,
sid int constraint fk_sid foreign key(sid) references student(sid),
score int)

insert into marks values(1,23),(6,95),(4,98),(2,17),(3,53),(5,13)
 

 select * from student

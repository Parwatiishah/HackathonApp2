create table vacancy (
Vid int primary key identity(1,1),
job_title nvarchar(20) not null,
job_des nvarchar(40) not null,
job_requirements nvarchar(40) not null,
job_location nvarchar(20) not null,
companyName nvarchar(20) not null,
contact_email nvarchar(20) not null,
post_date date not null,
userId int not null foreign key references Users(UserId)
)
select * from users;
select * from RoleList;
select * from vacancy;

CREATE VIEW vacancyView AS
SELECT vacancy.Vid, vacancy.job_title, vacancy.job_des, vacancy.job_requirements, 
       vacancy.job_location, vacancy.companyName,Users.UserId, vacancy.contact_email, vacancy.post_date, 
       Users.FullName AS postedBy, Users.UserEmail AS Company_email
FROM vacancy 
INNER JOIN Users ON vacancy.userId = Users.UserId;
select * from vacancyView;

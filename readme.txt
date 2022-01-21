To create database and Users table run the following command

CREATE DATABASE FlightSchoolProTest  

use FlightSchoolProTest  
go
CREATE TABLE Users  
(  
    Id bigint identity
    ,FirstName nvarchar(60) NOT NULL  
    ,LastName nvarchar(60) NOT NULL  
	,EmailAddress nvarchar(200) NOT NULL  

);  

Once you download this solution, you can open it in Visual Studio and press f5 to run it or click the play button.
It can then be tested using postman.

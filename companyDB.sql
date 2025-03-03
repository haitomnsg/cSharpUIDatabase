create database company;

use company;

create table login(
	id int IDENTITY(1,1) primary key NOT NULL,
	username varchar(30),
	password varchar(30)
);
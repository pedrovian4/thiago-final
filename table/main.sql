create database pinterest;
use pinterest;

create table user(
	id int not null auto_increment,
	password varchar(150) not null,
	email varchar(150) not null,
	create_time datetime not null,
	update_time datetime not null,
	constraint PK_User primary key (id)
);


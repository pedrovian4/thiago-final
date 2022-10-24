create table user(
	id int not null auto_increment,
	password varchar(150) not null,
	email varchar(150) not null,
	created_at datetime not null,
	updated_at datetime not null,
	constraint PK_User primary key (id)
);


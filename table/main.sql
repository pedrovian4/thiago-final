create database [if not exists] pinterest; 

use pinterest;

create table Users (id int auto_increment primary key, first_name varchar(100), 
middle_name varchar(100), last_name varchar(100), email varchar(255), 
user_password varchar(255), 
active bool default false,
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp
);

create table Posts (id int auto_increment primary key, user_id int, img_url text,  title varchar(100), description text,
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp, foreign key(user_id) references Users(id) );

create table Tags(id integer auto_increment primary key, tag_name varchar(100)  unique not null, 
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp);

create table Preference_Users(id int auto_increment primary key, user_id int not null , tag_id int ,    
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp, foreign key (user_id) references Users(id), foreign key(tag_id) references Tags(id));

create table Post_tags(id int auto_increment primary key, post_id int ,  tag_id int,
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp, foreign key (post_id) references Posts(id), 
foreign key (tag_id) references Tags(id));

create table Post_likes(id int auto_increment primary key, post_id int, user_liked_id int,   
createde_at timestamp default  current_timestamp,
update_at datetime default current_timestamp on update current_timestamp, 
foreign key (post_id) references Posts(id), 
foreign key (user_liked_id) references Users(id));

create table  recomendations (
id int auto_increment primary key,
created_at timestamp default  current_timestamp,
updated_at datetime default current_timestamp on update current_timestamp,
post_id int not null,
user_id int not null,
foreign key (post_id) references Posts(id),
foreign key (user_id) references Users(id)
);
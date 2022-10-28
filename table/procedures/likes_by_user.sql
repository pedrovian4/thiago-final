delimiter //

create function likes_by_user(id_post int, id_user int)
returns int
DETERMINISTIC
begin 
	declare somevar int;
	select count(post_id) from post_likes where post_id = id_post and user_liked_id = id_user into somevar;
	return somevar;
end//

delimiter ;

select likes_by_user(4, 1);
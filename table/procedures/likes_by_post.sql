delimiter //

create function fn_likes_by_post(id_post int)
returns int
DETERMINISTIC
begin 
	declare somevar int;
	select count(post_id) from post_likes where post_id = id_post into somevar;
	return somevar;
end//

delimiter ;






delimiter $$

create trigger recomendations_insert
after insert on Post_likes for each row
begin 
	insert into recomendations (post_id, user_id)
	select post_id, new.user_liked_id from Post_tags pt
	where pt.post_id<>new.post_id and tag_id in (select tag_id  from Post_tags where post_id  = new.post_id); 

end 
$$

delimiter ;


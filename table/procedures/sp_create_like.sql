delimiter //

create procedure create_like(in id_post int, in id_user int)
main: begin
	set @value = likes_by_user(id_post, id_user);
	if @value = 1 then 
		select "O usuário já curtiu o post";
		leave main;
	end if;
	insert into post_likes(post_id, user_liked_id) values(id_post, id_user);
	select "O usuário curtiu o post";
end//

delimiter ;

call create_like(3, 1);

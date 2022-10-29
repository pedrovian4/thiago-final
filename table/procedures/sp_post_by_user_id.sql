delimiter //

create procedure sp_post_by_user_id(in id_user int)
begin
	select 
	u.first_name, 
	u.last_name, 
	u.active, 
	p.img_url, 
	p.title, 
	p.description,
	t.tag_name,
	count(pl.user_liked_id) as curtidas
	from users u
	inner join posts p
	on u.id = p.user_id
	inner join post_likes pl
	on pl.post_id = p.id
	inner join post_tags pt 
	on pt.post_id = p.id
	inner join tags t 
	on t.id = pt.tag_id
	where u.id = id_user
	group by p.id;
end//

delimiter ;

call  post_by_userid(1);


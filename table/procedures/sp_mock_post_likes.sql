delimiter //

create procedure mock_post_likes(in tam_user int, in tam_post int)
begin
	declare cont_user int default 1; -- alterar valor padrão ao seu caso
	declare cont_post int default 3; -- alterar valor padrão ao seu caso
	while cont_user <= tam_user DO
		while cont_post <= tam_post DO
			call create_like(cont_post, cont_user);
			set cont_post = cont_post + 1;
		end while;
		set cont_user = cont_user + 1;
		set cont_post = 3;
	END while;
end//

delimiter ;


-- Os usuários do usuário 1 até o 38 irão curtir as postagems de 3 até 19 
-- Os valores padrões como 1 e 3, poderá ser alterado e colocado para qualquer número, 
-- desde que o intervalo entre o ínicio da contagem até o fim, não tenha sido excluido nenhum registro.
call mock_post_likes(38, 19); 
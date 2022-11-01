
// Não usei padrão de arquitetura porque isso aqui é simples logo é desnecessário
const express = require('express');
const app = express();
const mysql = require("mysql"); 
const connection = mysql.createConnection({
    host: 'localhost', 
    user:'root', 
    password:'root', 
    database:'pinterest'
});


app.use(express.json());

async function getUser (res,id){ 
    connection.connect();
    connection.query(`select * from Users where id =${id}`, (error, results, fields)=>{
        if (error) throw error;

        res.send(results);
    });

    connection.end();
}

async function getUsers (res){ 
    connection.connect();
    connection.query("select * from Users", (error, results, fields)=>{
        if (error) throw error;

        res.send(results);
        return results;
    });

    connection.end();
}

async function getPosts(res){
    connection.connect();
    const sql = "select Posts.title,Posts.img_url, Tags.tag_name, Posts.id as postid, Tags.id as tagid from Post_tags left join Posts on Post_tags.post_id = Posts.id left join Tags on Post_tags.tag_id = Tags.id"
    connection.query(sql, (error, result, fields) =>{
        if (error) throw error;
        res.send(result);
    } )
    connection.end();
}

async function getUserLiked(res){
    connection.connect();
    const sql = "select u.id as userId, u.first_name as userName, p.title as postTitle, p.id as PostId from Post_likes pl left join Posts p on pl.post_id = p.id left join Users u on pl.user_liked_id = u.id";

    connection.query(sql, (error, result, fields) =>{
        if (error) throw error;
        res.send(result);
    } );
    connection.end();
}



async function getUserRecomendation(res,id){

    connection.connect();
    const sql = `select * from recomendations r left join Posts p on r.post_id = p.id left join Users u on r.user_id = u.id  where r.user_id =  ${id}`;

    connection.query(sql, async (error, results, fields) =>{
        if (error) throw error;

        results>[] ? res.send(results) : res.send("Usuário não curtiu nenhum post para ter recomendações!");
    } );

    connection.end();

}




app.get('/', async (req, res)=>{
     res.send("Bem vindo a nossa API!");
});

app.get('/users', async (req, res)=>{
     getUsers(res);
});
app.get('/user/:userId', async (req, res)=>{
    getUser(res, req.params.userId);
});
app.get("/posts", async (req, res)=>{
    getPosts(res);
});

app.get('/likes', async(req, res)=>{
    getUserLiked(res);
});

app.get('/recomendations/:userID', async( req,res) =>{
    getUserRecomendation(res,req.params.userID);
});





app.listen(3000, ()=> console.log('Server running into htpps://localhost:3000'));
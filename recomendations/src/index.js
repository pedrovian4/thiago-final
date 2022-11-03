
// Não usei padrão de arquitetura porque isso aqui é simples logo é desnecessário
const express = require('express');
const mysql = require("mysql"); 
const  multer = require("multer");
const upload = multer();

const connection = mysql.createPool({
    connectionLimit:10,
    host: 'localhost', 
    user:'root', 
    password:'root', 
    database:'pinterest'
});

const app = express();
app.use(express.json());



async function getUser (res,id){ 
    connection.query(`select * from Users where id =${id}`, (error, results, fields)=>{
        if (error) throw error;

        res.send(results);
    });


}

async function getUsers (res){ 
    connection.query("select * from Users", (error, results, fields)=>{
        if (error) throw error;

        res.send(results);
        return results;
    });

}

async function getPosts(res){
    const sql = "select Posts.title,Posts.img_url, Tags.tag_name, Posts.id as postid, Tags.id as tagid from Post_tags left join Posts on Post_tags.post_id = Posts.id left join Tags on Post_tags.tag_id = Tags.id"
    connection.query(sql, (error, result, fields) =>{
        if (error) throw error;
        res.send(result);
    } )
}

async function getUserLiked(res){
    const sql = "select u.id as userId, u.first_name as userName, p.title as postTitle, p.id as PostId from Post_likes pl left join Posts p on pl.post_id = p.id left join Users u on pl.user_liked_id = u.id";

    connection.query(sql, (error, result, fields) =>{
        if (error) throw error;
        res.send(result);
    } );
}



async function getUserRecomendation(res,id){

    const sql = `select * from recomendations r left join Posts p on r.post_id = p.id left join Users u on r.user_id = u.id  where r.user_id =  ${id}`;

    connection.query(sql, async (error, results, fields) =>{
        if (error) throw error;

        results>[] ? res.send(results) : res.send("Usuário não curtiu nenhum post para ter recomendações!");
    } );
}


async function likeUser(userId, postId, res){

    const insertsql  =`insert into Post_Likes (post_id, user_liked_id) values  (${userId},${postId})`;

    const check = async ()=>{
        const sqlCheckIfPostExists = `select 1 from Posts where id = ${postId}`; 
        const sqlCheckIfUserExists = `select 1 from Users where id = ${userId}`;
        const checkpost = connection.query(sqlCheckIfPostExists, async(error, results, fields)=>{
            if (error) throw error;
            if (results.length >0) return true;
            
            return false;  
              });
        const checkuser  = connection.query(sqlCheckIfUserExists, async(error, results, fields)=>{
            if (error) throw error;
            if (results.length >0) return true;
            
            return false;
        });

        return checkuser  && checkpost;
    }

    if(check){
        connection.query(insertsql, async (error, results, fields)=>{
            if (error) throw error;

            res.send("User inserted");
            return;
        });
    
    res.send("Post Não existe ou Usuario ou Post ja foi curtido pelo usuario");
    }
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

app.post('/likeUserPost',upload.none() ,async (req, res)=>{

    const userId = req.body.userId; 
    const postId = req.body.postId;

    // console.log(req.body);
    // if(userId && postId) likeUser(userId, postId, res);

    res.send('Valores nulos');
});





app.listen(3000, ()=> console.log('Server running into htpps://localhost:3000'));
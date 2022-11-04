## Curtir post

## Passar dados aqui 
curl --request POST \
  --url http://localhost:3000/likeUserPost \
  --header 'Content-Type: multipart/form-data' \
  --form userId=3 \
  --form postId=2 \
  --form =
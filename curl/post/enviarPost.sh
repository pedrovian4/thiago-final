## Enviar post



### Passar 
curl --request POST \
  --url https://localhost:5001/api/post \
  --header 'Content-Type: multipart/form-data' \
  --form img=@/home/pedro/Pictures/Wallpapers/1126615.jpg \
  --form userId=2 \
  --form title=AMEM \
  --form 'description=isso é um teste' \
  --form tagId=2
# mini-project-realtime

# how to create image 
 docker build -t name-image .

# how to create container and run port: 8080
docker run -d -p 8080:8080 --name name-container name-image

# how to get list docker image
docker images

# how to stop docker image

# how to remove docker container and image
docker stop pos-api-container

docker rm pos-api-container

docker rmi pos.api or docker rmi id

# show docker running
docker ps

# -----------Database--------------
# create migration 
dotnet ef migrations add name-migration 

# run migration 
dotnet ef database update
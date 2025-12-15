# mini-project-realtime

# how to create image 
 docker build -t name-image .

# how to create container and run port: 8080
docker run -d -p 8080:8080 --name pos-api-container pos.api

# how to get list docker image
docker images

# how to stop docker image

# how to remove docker container and image
docker stop pos-api-container

docker rm pos-api-container

docker rmi pos.api or docker rmi id

# show docker running
docker ps
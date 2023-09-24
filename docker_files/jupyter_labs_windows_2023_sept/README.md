Source: https://medium.com/@alexjsanchez/jupyter-lab-on-docker-with-windows-368a24e18d0

1. Set RAM usage to 4 GB (default is 2 GB)
2. Run commands to build the image
```text
D:
cd D:\Users\Henri\Doccuments\GitHub\ExperimentationMonoRepo
docker build -t jupyterlab .\docker_files\jupyter_labs_windows_2023_sept
```
3. `docker run -p 8888:8888 jupyterlab`



Docker Command Guide

```text
# see all running docker containers
docker ps

# see all available docker containers
docker ps -a

# start container (mapping your 9999 to docker's 8888)
docker run -p 9999:8888 mycontainer

# stop container
docker stop CONTAINER_ID

# build container (after creating "Dockerfile")
docker build -t mycontainer ./path/with/dockerfile/

# run linux docker container with bash
docker pull ubuntu:20.04
docker run ubuntu:20.04
docker run -it ubuntu:20.04 /bin/bash
```

```text
# attach to a container and run commands


# 
```
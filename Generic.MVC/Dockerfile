#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/aspnet
MAINTAINER pramodlovete36@gmail.com
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .

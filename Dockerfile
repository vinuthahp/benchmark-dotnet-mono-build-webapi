FROM mono:latest
MAINTAINER hudsonmendes
ENV DATABASE_CONNECTION_STRING="Server=(local)\SQLEXPRESS;Database=ApiPeople;Integrated Security=SSPI"

RUN mkdir -p /src/AndrewJenkins && \
mkdir -p /app

COPY . /src/AndrewJenkins

WORKDIR /src/AndrewJenkins
RUN nuget restore /src/AndrewJenkins && \
xbuild /p:Configuration=Release /src/AndrewJenkins/AndrewJenkins.sln && \
cp /src/AndrewJenkins/ApiPeople/bin/Release/* /app

WORKDIR /app
RUN rm -rf /src/AndrewJenkins && \
apt-get -y -qq update && \
apt-get -y -qq install xmlstarlet && \
xmlstarlet ed -L -u "//configuration/connectionStrings/add[@name="DataServices"]/@connectionString" -v "$DATABASE_CONNECTION_STRING" /app/ApiPeople.exe.config && \
apt-get -y -qq remove xmlstarlet && \
apt-get -y -qq autoremove

ENTRYPOINT ["mono", "ApiPeople.exe", "--port", "5000"]
EXPOSE 5000

# Smilr.DotNet - ASP.NET Core 2.0 Server

Smilr microservice, RESTful data API

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```

## Run in Docker

```
cd src/Smilr.DotNet
docker build -t Smilr.DotNet .
docker run -p 5000:5000 Smilr.DotNet
```

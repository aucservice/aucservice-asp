URL = https://auc-service.herokuapp.com/swagger/index.html
# aucservice-asp

# Dockerfile

```Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AucService.csproj", "./"]
RUN dotnet restore "AucService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "AucService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AucService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AucService.dll"]
CMD ["dotnet", "AucService.dll", "--server.urls", "http://+:$(PORT)"]
```

# Make Bid

## Request sample

```
$ curl -X POST $URL/Auction/bid 
-H "Content-Type: application/json" 
-d "{""name":"Roman",
      "lotId":"2",
      "amount":100000,
      "token":"someToken"}"
```

## Result

200 OK:

```
After making a bet, the method sends all customers information 
about the new lot price and if no one offers more in a minute, 
the last user takes the lot. Otherwise, the auction continues.
```

# Get lot by id

## Request sample

```
$ curl -X GET $URL/Auction/lot?lotId=A
```

## Response sample

200 OK:

```
{
  "id": "A",
  "title": "test lot",
  "imageUrl": null,
  "description": "somethingsomething",
  "bidding_end": 1642608173
}
```

# Get Lots

## Request sample

```
$ curl -X POST $URL/lots
```

## Response samples

200 OK:
```
{
  "2": {
    "id": "2",
    "title": "Pixel Cat",
    "image_url": "https://stickershop.line-scdn.net/stickershop/v1/product/1418294/LINEStorePC/main.png;compress=true",
    "description": "Pixel Cat is a logo for indie 2D platformer released in 2017 by 
        Amnesia Games. The player assumes the role of Pixel Cat and must rescue him from the monsters, 
        pits and traps within his hometown by jumping and rollingamazing cat.",
    "bidding_end": 1642610262
  },
  "3": {
    "id": "3",
    "title": "Castle on the Hill",
    "image_url": "https://cdn.mos.cms.futurecdn.net/jbCNvTM4gwr2qV8X8fW3ZB.png",
    "description": "Castle on the Hill is a pixel picture created by Eric Becklin in 1989. 
        Other popular pixel art include Aaron Smith's SFX pixel portraits, Marvy Todd's 
        RPGs like Ninja Elves (1989) and Dungeon (1988), Derek Yu's survival horror picture Rewek.",
    "bidding_end": 1642610423
  },
  "4": {
    "id": "4",
    "title": "Mono Lida",
    "image_url": "https://external-preview.redd.it/p&s=ed39cc1e0141d069cac38e73f0cdd324ba45e596",
    "description": "Mono Lida is an NFT remake of Mona Lisa created by artist Shinjiro Kitamura. 
        In this webtoon, love is the only thing that can bring Mona Lisa and Mono Lida together again. 
        The content in this webtoon is comparable to that of graphic novels and manga.",
    "bidding_end": 1642664387
  }
}
```

# Get User By Id and all his lots.

## Request sample

```
$ curl -X GET $URL/Auction/user?name=Roma
```

## Response sample

200 OK:

```
{
  "username": "Roma",
  "lots": [
    {
      "id": "2",
      "title": "Pixel Cat",
      "image_url": "https://stickershop.line-scdn.net/stickershop/v1/product/1418294/LINEStorePC/main.png;compress=true",
      "description": "Pixel Cat is a logo for indie 2D platformer released in 2017 by Amnesia Games. 
          The player assumes the role of Pixel Cat and must rescue him from the monsters, 
          pits and traps within his hometown by jumping and rollingamazing cat.",
      "bidding_end": 1642610262
    }
  ]
}
```

# Get All Users

## Request sample

```
$ curl -X GET $URL/Auction/users
```

## Response sample

200 OK:

```
{
  "users": ["herman", "user", "Test1335678", 
    "Hhhhhhhhh", "user3", "Roma",
    "rdoskoch", "Dima", "Adam",
    "DimaS", "AdamB", "Dimaa", "TEstTest"]
}
```

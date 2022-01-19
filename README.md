<p align="center">
<img src="https://travis-ci.org/klugjo/hexo-autolinker.svg?branch=master">
<img src="https://img.shields.io/amo/stars/youtube?color=dd&label=Rate&logo=ss&logoColor=ss">
<img src="https://img.shields.io/amo/v/asd?label=version">
<img src="https://badges.frapsoft.com/os/v1/open-source.svg?v=103">
<img src="https://img.shields.io/crates/d/youtube">
 </p>
 
URL = https://auc-service.herokuapp.com/swagger/index.html
# aucservice-asp

# `Functionality`
## `LogIn`
<p align="center">
  <kbd> <img src="Pics\short.gif" alt="drawing" width="250" style="border-radius:10px"\></kbd>
</p>

## `Main`
<p align="center">
  <kbd> <img src="Pics\auction_demo.gif" alt="drawing" width="700" style="border-radius:10px"\></kbd>
</p>


# Описание работы [SignalR](https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr)
```
ASP.NET SignalR - это библиотека для ASP.NET разработчиков, которая упрощает добавление в приложения компонентов, 
работающих в реальном времени. Функциональность, работающая в реальном времени – это способность сервера отдать 
свежие данные подключенным клиентам немедленно, вместо того, чтобы ждать пока клиенты запросят эти данные.

SignalR приложения могут масштабироваться на тысячах клиентах, используя Service Bus, SQL Server или Redis.

Так же с помощью SignalR можно обрабатывать крупномасштабные клиентские подключения.
Служба SignalR предназначена для крупномасштабных приложений, которые работают в режиме реального времени. 
Служба SignalR позволяет совместно использовать несколько экземпляров для масштабирования до миллионов 
клиентских подключений. Служба также поддерживает несколько глобальных регионов с целью обеспечения разделения, 
высокой доступности или аварийного восстановления. 

SignalR может использовать в качестве транспорта и websockets, и longpolling. 
Транспорт можно задать, а можно оставить на откуп SignalR, который сам выберет нужный.
В случае, если можно использовать websocket, то он будет работать через websocket, если такой возможности нет, 
то он будет спускаться дальше, пока не найдёт приемлемый транспорт.
```
Существует много различных способов программирования с использованием службы Azure SignalR. <br>
К ним можно отнести некоторые из перечисленных ниже примеров:

* Масштабирование приложений ASP.NET Core SignalR. Интегрируйте службу Azure SignalR с приложением ASP.NET Core SignalR, чтобы масштабировать сотни тысяч подключений.
* Создание бессерверных приложений, работающих в реальном времени. Интегрируйте службу "Функции Azure" со службой Azure SignalR, чтобы создавать бессерверные приложения, работающие в реальном времени, на таких языках, как JavaScript, C# и Java.
* Отправка сообщений с сервера клиентам через REST API. Служба Azure SignalR предоставляет REST API, чтобы приложения могли публиковать сообщения в клиентах, подключенных с помощью службы SignalR, на любом языке программирования с поддержкой REST.
[Читать далее](https://docs.microsoft.com/ru-ru/azure/azure-signalr/signalr-overview)

# `Dockerfile`

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

# `Make Bid`

## Request sample

```console
curl -X POST $URL/Auction/bid 
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

# `Get lot by id`

## Request sample

```console
curl -X GET $URL/Auction/lot?lotId=A
```

## Response sample

200 OK:

```json
{
  "id": "A",
  "title": "test lot",
  "imageUrl": null,
  "description": "somethingsomething",
  "bidding_end": 1642608173
}
```

# `Get Lots`

## Request sample

```console
curl -X POST $URL/lots
```

## Response samples

200 OK:
```json
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

# `Get User By Id and all his lots`

## Request sample

```console
curl -X GET $URL/Auction/user?name=Roma
```

## Response sample

200 OK:

```json
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

# `Get All Users`

## Request sample

```console
curl -X GET $URL/Auction/users
```

## Response sample

200 OK:

```json
{
  "users": ["herman", "user", "Test1335678", 
    "Hhhhhhhhh", "user3", "Roma",
    "rdoskoch", "Dima", "Adam",
    "DimaS", "AdamB", "Dimaa", "TEstTest"]
}
```

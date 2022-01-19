URL = https://auc-service.herokuapp.com
# aucservice-client-asp
# Get lot by id

## Request sample

```
$ curl -X GET $URL//Auction/lot?lotId=A
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
"1": {
    "id": "1",
    "title": "test lot",
    "imageUrl": null,
    "description": "somethingsomething",
    "bidding_end": 1642609563
  },
  "2": {
    "id": "2",
    "title": "Pixel Cat",
    "imageUrl": null,
    "description": "Pixel Cat is a logo for indie 2D platformer released in 2017 by Amnesia Games. The player assumes the role of Pixel Cat and must rescue him from the monsters, pits and traps within his hometown by jumping and rollingamazing cat.",
    "bidding_end": 1642610262
  },
  "3": {
    "id": "3",
    "title": "Castle on the Hill",
    "imageUrl": null,
    "description": "Castle on the Hill is a pixel picture created by Eric Becklin in 1989. Other popular pixel art include Aaron Smith's SFX pixel portraits, Marvy Todd's RPGs like Ninja Elves (1989) and Dungeon (1988), Derek Yu's survival horror picture Rewek.",
    "bidding_end": 1642610423
  },
}
```

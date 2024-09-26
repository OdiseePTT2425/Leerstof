# Testcase AddToCart.001

status: :green_check_mark: / :x:

{Test Case Description}

created by: jens
reviewed by:  ----
version: 00.0


## Preconditions
| Precondition |
| ------------ |
| Klant is ingelogd  |
| Er is minstens 1 artikel in de catalogus  |
| Er is minstens 1 artikel op voorraad |


## Test Data
| Field      | Value   |
| ---------- | ------- |
| Artikelnaam | p |
| Artikelvoorraad | 2  |
| Artikelprijs | 10.00 |



## Test Steps
| Step | Step detail | Expected Result | Actual Result |
| ---- | ----------- | --------------- | ------------- |
| 1    | Klant klikt op addToCart | Artikel p toegevoegd aan winkelwagen |               |
|      |                          | Totaalprijs winkelwagen is 10        |               |
|      |                          | Indicatie aantal producten in winkelwagen is 1        |               |

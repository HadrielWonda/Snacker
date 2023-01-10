# Domain Models

## Menu

'''csharp
class Menu 
{
    Menu Create();
    void AddSnack(Snack snack);
    void RemoveSnack(Snack snack);
    void UpdateSection(MenuSection section);
}

'''

'''json

{
"id" : "00000000000-0000000-00000-00000-000000000000000000",
"menuname" : "Wale's Delicious Snack Menu",
"description" : "A snack menu made by wale that is delicious and tanterlising",
"averageRating" :4.5,
"sections" : " {
    "id":"00000000000-0000000-00000-00000-000000000000000000",
    "name": "Appetizers",
    "description": "Starting snack",
    "items" :{
       "id" : "00000000000-0000000-00000-00000-000000000000000000",
       "name": "Fried eggs and Okra"
       "description": "Well seasoned fried eggs spiced with sugar combined with drawing okra soup",
       "price": 5000
      } 

},
"createdDateTime": "2023-08-01T00:00.00000002",
"updatedDateTime" : "2023-08-01T00:00.00000002",
"hostId" : "00000000000-0000000-00000-00000-000000000000000000",
"snacksId" : "00000000000-0000000-00000-00000-000000000000000000",
"snackreviewIds" : "00000000000-0000000-00000-00000-000000000000000000"
}
'''
# Welcome to AJ Gebara's Spreetail Take Home Project

## What is the App?

## List of Commands

| Command       | Parameters          | Example                    | Description                                            |
|---------------|---------------------|----------------------------|--------------------------------------------------------|
| ADD           | `<key> <member>`    | `ADD Batman Joker`         | Adds a key and member pair to dictionary               |
| KEYS          | *No parameters*     | `KEYS`                     | Returns list of keys                                   |
| MEMBERS       | `<key>`             | `MEMBERS Batman`           | Returns members of a specific key                      |
| REMOVE        | `<key> <member>`    | `REMOVE Batman Joker`      | Removes a specific member from a key                   |
| REMOVEALL     | `<key>`             | `REMOVEALL Batman`         | Removes all members in a key, including the key itself |
| CLEAR         | *No parameters*     | `CLEAR`                    | Removes all key and member pairs in dictionary         |
| KEYEXISTS     | `<key>`             | `KEYEXISTS Batman`         | Returns true if key exists in dictionary               |
| MEMBEREXISTS  | `<key> <member>`    | `MEMBEREXISTS Batman Joker`| Returns true if member exists in a key                 |
| ALLMEMBERS    | *No parameters*     | `ALLMEMBERS`               | Returns all members in the dictionary                  |
| ITEMS         | *No parameters*     | `ITEMS`                    | Returns all key and member pairs in dictionary         |
| EXIT          | *No parameters*     | `EXIT`                     | Closes application                                     |


## Constraints

* Traditionally, the elements of a dictionary are called keys and values. In this app, the term 'members' is used to refer to what are typically known as values
* Commands are case-sensitive. They must be uppercase
* Keys and Members must be one word. Ex: `ADD Batman Mr.Freeze` not `ADD Batman Mr. Freeze`

## How do you get the app running?

## How do you run the unit tests?

## Future Iterations & Areas of Improvement
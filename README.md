# UserGenerator
A simple .NET user name and password generator

Usage:

####Generate a single User
```C#
(...)
    User user = UserGenerator.GenerateUser();
(...)
```

####Generate 10 users at once
```C#
(...)
    List<User> userList = UserGenerator.GenerateUsers(10);
(...)
```

Currently, there are 100 options for the first and last names and 50 options for the domain, allowing for 500 000 different options. And while collisions are obviously possible, early testing indicated that up to 100 users generated the collision rate is well under 1%.


A few options can be changed according to the table

| Option | File | Description
|---|---| --- 
| First Name | First.cs | List of possible first names
| Last Name | Last.cs | List of possible last names
| Domain Name | Domain.cs | list of possible domain names
| Phonetic Representation | Phonetic.cs | Phonetic representation of the possible password characters



# WPF_Article_Browser

## Presentation

This is a WPF project for a .NET course at EPITA during semester 6 (3rd year student) of the 2022 promotion. This course teaches us the basics of the .NET Framework and C# programming over 4 sessions, ending with this project. This project was also my first experience designing a desktop application in C#.

The project subject went as follows:

---
Design a solution that allows the user to publish articles on a front-end. The front-end can be either a desktop application (WPF), or a web application (MVC).

It must have the following features:
- A page showing a list of all articles in a condensed form
- A page allowing the user to create articles
- A page allowing the user to see the full article in details, which increments the article's view counter when accessed

An article contains an image, a text area, a date of publication, and a view counter. For simplicity purposes, the text area can be plain text.

The project has the following constraints:
- Any back-end must be made using the .NET Core framework (the front-end can be made using the .NET Framework)
- The database must be Microsoft SQL Server
- To access the database, the Entity Framework must be used
- The project must use a layered architecture (Interface, BusinessManagement, DataAccess, DBO)

The project can contain these bonus features:
- An account and login system that will act as a security feature: only administrators are allowed to publish articles
- HTML formating for the article's text
---

I personnaly went for the WPF Desktop Application. I also decided that the application would perform the database requests on its own and not through an external service, therefore no separate server/back-end project was needed. My application therefore only uses the .NET Framework, and not .NET Core. This decision was made to make sure I would have enough time to complete everything I needed to make the application work.

I did not have time to implement the HTML formating of the articles, but I did plan the login system from the start. I also decided to add authors to articles to better reflect the account system, and added article titles as well for a more comfortable experience.

In order to make pages more dynamic, I use the MVVC design pattern.

## Database creation

In its current implementation, the application will look for the database on the host computer. This means in order to use the application, you need to have an instance of SQL Server running on your computer, with the correct database loaded. If no database is found, the application will show an error message after startup, then close.

The script that creates the database is `database.sql`, located in `WPF_Article_Browser\WPF_Client\Resource\`

I do not have access to a second computer, so I have not been able to properly test that the application would find the database on a different computer.

## Screenshots and usage guide

Here is an [Imgur post](https://imgur.com/a/LJusVFV) containing sample screenshots of the application.

Some important things to note:
- The article titles are limited to 40 characters
- The usernames are limited to 40 characters
- The passwords are limited to 32 characters
- The passwords are stored in plain text in the database, I did not have enough time to figure out encryption

## What could be improved

- Encrypting the passwords would be the first next-step. Storing passwords as plain text is never a good idea, no matter where they are stored.

- The main limitation of the application is the need for a local database. The first thing to improve would be to connect the application to a distant database, removing the requirement for the end user to install it on their computer.

- To further improve the database issue, having the application relay its queries to a distant web server could also help isolate the client. This would mean better security, the need for a web server that would then make the database queries, handling of HTTP requests, and overall be a good learning experience.

- The HTML formating of articles would be a big improvement for user experience. Better formating of the article page overall would be needed, as right now the image is too big and the horizontal space is not properly used.

- The article previews can very much be improved. Currently, the portion of the text that is displayed has been hardcoded to be the first 60 characters of the article, followed by '...'. However it would be better to make the application dynamically adjust that value to fit the size of the window, and/or add automatic newlines when needed.

- In case HTML formating is supported, improving the 'New Article' page to also launch a preview window would be a good improvement.

- A logical feature would be the ability to rename, edit and delete articles.

- Sorting the articles by most recent by default and adding other sorting options (author, views, date...) would make it easier to use when many articles were posted.

This list goes on and on, these were just the main possible improvements that came to my mind, but a lot more can be done, including improvements to the code itself probably.

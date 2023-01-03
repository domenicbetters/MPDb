# Mayvue-Motion-Picture-Database

This is a Movie Database running with an web.net api back end and a SQL database back end.  It utilizes Vue to display the UI for the client front end.  

Utilized Font Awesome additionally and if I were to rework this in the future, I would most likely bring in Bootstrap to create a customized alert /validation system instead of the browser default.

When first running using Visual studio, you must first set up the database by running add-migration InitialCreate
then running update-database.

Functionality:

You are able to add a title, description and release year for any movie you wish to store in the database.
You are able to edit, copy, and delete existing entries
Forms will validate and alert you to any faulty or absent values required by the database.
Name and Year are sortable from the table view.  

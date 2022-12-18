# Project_C_sharp_and_.NET

This application allows you to save contacts in a list. Each contact consists of the name of the person, company etc. aswell as the phone numbers. You can add both a GSM number and/or a landline number. Once a contact has been created, it will show up in the list on the main page. From there you can edit the contact by pressing it, which will send you to the edit screen. Here both numbers can be edited, but not the name. There is also a button to delete the contact.
Important: you can't add contacts with a name that is already in use (not case-sensitive). Also the phone number must be the correct lenght (local number starting with 0 or international number starting with country code).

These contacts are stored in a web API, for which the code is located under the 'WebAPI' folder. To set it up using docker, run the following commands from the terminal:
- **build and start webserver:** docker compose up
- **Setup migration pattern for database:** docker exec -it migrations /root/.dotnet/tools/dotnet-ef migrations add InitalMigration
- **Update database with migration patern:** docker exec -it migrations /root/.dotnet/tools/dotnet-ef database update

After this the webserver will be listining on localhost:8000 and the app will be able to access it if run from the same device. If the app is run on another device you will need to replace the url in the apps code with the IP adress or DNS address of the device that is running the webserver

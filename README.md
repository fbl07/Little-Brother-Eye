# Little Brother Eye
A website used by the Injustice 2 community to keep track of the events currently happening in game

**NOTE** : this app requires a SQL Server database to work, you'll need to update the web.config file in the web app project and the app.config file in the data access project to replace the placeholder by your actual connection string. Let me know if you have problems with this.

It also uses a Send Grid API, but that's only to send out emails for the API Keys, it shouldn't be needed for testing unless you specifically testing this part. 

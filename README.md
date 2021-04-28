# Project guide

#### Add  the following key value pairs to the either the secrets.json file or appsettings.json file 
- key: **jwtKey** , value: could be any string of your choice.
- key: **WebClientUrl**, value : must be the value of the url of the react client consuming the api.
- On the react client create an .env file and add this key value pair to it **REACT_APP_API_URL=https://localhost:44339/api**


Seeded users can be found in the ~/Infrastructure/CodingTestContext.cs file. 
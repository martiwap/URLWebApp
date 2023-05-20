#Hello 

To open and use this project, please follow the below instructions:

- clone the repository (from master branch)
- open command line/terminal/powershell on your machine
- from here open/cd the folder you cloned
- open/cd the folder containing the csproj (should be cd .\UrlWebApp\)
- run the command: donet run
- the solution will build and a series of log/info will appear. 
- click/open the localhost url prompted in the command line (it should say 'Now listening on: http://localhost:7136' )

Once you do that, you should have a open web browser the URLWebApp open in your browser.

This application will take any url and convert them into a custom short URL. 
For instance:
- you can enter any URL of your choise inside the 'Your URL: ' text box (for example https://www.youtube.com/@PewDiePie),
- and choose a custom alias (like 'myFav')
- and press Submit
You will be prompted with a url like http://localhost:7136/myFav . You can click or paste this link in any browser (while the app is running) and it will redirect youto the original URL. 

Note: 
- as this is not a published app, the project needs to run for this to work and there is no custom domain specified (besides working with http://localhost:7136)
- if you don't provide a URL to convert an exception will be thrown
- if your alias is already in use or not provided  an exception will be thrown
- the design is a bit crap, I know! I am aware of it

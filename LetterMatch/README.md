## Running the Tests

- Install Chromedriver
  * `brew install chromedriver`
- Start the application, with the default (test) database
  * `dotnet watch run`
- Open a second terminal session and run the tests
  * `dotnet test`

- ## Setting up test database
  * `cd into LetterMatch. Run command 'dotnet ef database update'
- Setting up development database
  * `cd into LetterMatch. Run command 'DATABASE_NAME=lettermatch_csharp_development dotnet ef database update'

IF MIGRATIONS FILES STILL RED. SAVE CHANGES AND RESTART VS
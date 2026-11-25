# Binding .NET Core API Yousign (now Youtrust)

This is the source of the Alchiweb.Yousign Nuget package, with a sample project (need to be used with a Yousign account).

## Yousign binding: "Alchiweb.Yousign" project

This is the nuget package to use the Yousign API in a .NET Core project.

Documentation of the Yousign API is available at: https://developers.youtrust.com/reference/webhook-1

## Sample project

The sample project can be useful for starting to test the Yousign API.

Note that this sample project is using AlchiwebApp nuget packages (with Ardalis.Specification).

### Project "Alchiweb.Yousign.Sample"

This sample get the Yousign events and store them in a local database (SQLServer).

Launch the project with the 'https' profile.

Use the "**Alchiweb.Yousign.Sample.http**" file to test the API endpoints:
- POST /webhook/yousign/ -> webhook to receive events from Yousign (with signature verification) and store them in the database 
- GET /api/signature -> get signatures from the database with filters and sorting
- GET /api/signature/{id} -> get a specific signature from the database

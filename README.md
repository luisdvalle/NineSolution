# NineSolution
Standalone JSON-based web service. It filters JSON data and return some determined fields.

It receives details From a list of shows in the request payload, return the ones with DRM enabled (drm: true) and at least one episode (episodeCount > 0).

The returned JSON should have a response key with an array of shows. Each element should have the following fields from the request:

- image - corresponding to image/showImage from the request payload
- slug
- title

Error Handling
If invalid JSON is sent, the application will return a JSON response with HTTP status 400 Bad Request, and with a `error` key containing the string Could not decode request. For example:

{
    "error": "Could not decode request: JSON parsing failed"
}

Structure of this application

- An ASP.NET WebAPI Core 2.0 project
- A .NET Standard 2.0 library containing the abstractions used in this project
- A UnitTest .NET Core 2.0 project

Other details:

- A Home Page for this project is available through a GET request on http://nuevesolution.azurewebsites.net/
- API Endpoint to process data available through a POST request on http://nuevesolution.azurewebsites.net/
- API specifications available on http://nuevesolution.azurewebsites.net/swagger

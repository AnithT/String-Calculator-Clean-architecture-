# ULCodingTask
Based on the given task, I have created an ASP.NET Core web application which required the creation of an API that evaluates string expressions consisting of non-negative integers and mathematical operators with operator precedence. I chose to adopt Clean Architecture approach. I divided the application into presentation, application, domain layers and infrastructure layer which allows for separation of concerns and modularity. I have used all the basic approaches used to create an ASP.NET Core web application . I have used Json Web Token(JWT) authorization and authentication for accessing the expression evaluation API using bearer token. So the the API can be accessed only through token. The token can be created by an API through token service.

APIs used

For token creation : POST - api/Authentication/login
For evaluating the expression : GET - api/MathExpression   PARAMS - Give the string expression which you want to evaluate

Here are the different stages and details of commits of the web application I have developed.

Commit 1 - Initial commit where I have created a C#.NET web application

Commit 2 - Modified the project structure to follow the Clean Architecture pattern, for modularity,testability and scalability.
           Implemeneted the main expression evaluation logic in MathExpressionEvaluator.cs.
           Modified controller classes MathExpressionController.cs, to receive HTTP request,validate incoming data and send response.
           Added Lifetime for the instances of MathExpressionEvaluator and MathExpressionService classes

Commit 3 - Added an exception handler middleware to handle all the exceptions that is happening in the application.      

Commit 4 - Modified exception middleware handler class ExceptionMiddleware.cs to provide custom exception messages.
           Added Logger changes to log the stack trace and exception messages to a local file.
           Added an extension class StringExtension.cs to check whether the string reaching the API is valid. By checking whether any other charecters are there other than numbers and opearators in the string.

Commit 5 - Added unit testing framework using XUnit for doing the unit testing of three basic scenarios of expresssion evaluation logic.

Commit 6 - Added authentication and authorization logics and layers using JWT(Json Web Token).
           Added a controller and service to retreive Token.
           Added necessary changes to program.cs to check authorization and authentication.
           Added authentication controller class called AuthenticationController.cs for retreiving token using an API call.
           Added necessary authorization filter to the MathExpressionController.cs.

Commit 7 - Refined code by removing unused namspaces and comments.

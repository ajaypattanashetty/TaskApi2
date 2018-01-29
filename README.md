# TaskApi2
Task Web API for managing a list of "to-do" items.
This an ASP.NET Core Web API Sample.

API's:
 1. GET: http://localhost:61684/api/task

 2. POST: http://localhost:61684/api/task

      Body: (application/json)
      {
          "name":"Take dog for a walk!",
          "isComplete":true
      }
      
 3. PUT: http://localhost:61684/api/task/1
 
      Body: (application/json)
      {
          "id": 1,
          "name":"Take dog for a walk!",
          "isComplete":true
      }
  
 4. DELETE: http://localhost:61684/api/task/1
  

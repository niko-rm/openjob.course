Project Description
The current application provides a web site with managing ClassRooms, Lessons and their Students.
Resource: https://docs.microsoft.com/en-us/aspnet/mvc/overview/performance/using-asynchronous-methods-in-aspnet-mvc-4

The solution is presented as
- Web Application: The application used to manage all the stuff :)
- APIs: The application used to manage all the business logics of our Web application;
- DbCourse: The Data Layer of our application composed in a Model and their composite partial classes;
	NB: Make sure when you create them, in order to set right the namespace, use OpenJob.Course.DbCourse.Entities instead 
	of OpenJob.Course.DbCourse or the partial class combination will not work.
- DTOs: The application Domain model this will be used as Data Transfer Object from DataLayer to the Service;

Base assumptions:
- From DataLayer to ServiceLayer: You will exchange from Entities to DTOs;
- From Service to PresentationLayer: You will exchange from DTOs to ViewModels;
- We will evaluate team work and technical skills in each team:
	- Choose skills and select an area of competence for each team member;
	- Write on a post-it your task and its status:
		- discuss each task (choose your attacking strategy a task all togeter or everyone works on their own task);
		- Give each task a priority.

What ToDo: 
Currently the Web application has three controllers
- ClassRooms;
- Lessons;
- Students;
- The application doesn't have a navigation so you have to navigate to each page using the Url (Controller/Action/{params})

1. Attach the controllers to the APIs rather than directly to EntityFramework (Moving the EF inside the APIs).
   Complete the task to achieve:
	- Insert (POST);
	- Edit   (PUT);
	- Delete (DELETE);

	Resource: How to call a web api from a client
	https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client

1.a Refactoring the current code to provide an efficent organization using SOLID methodologies.
1.b Remove all the references to DbCourse library Web.

2. Create the function that associate a ClassRoom, a Lesson and a Student using a bootstrap modal and JQuery following these steps:
	- Create a controller called SchedulerController;
	- Add the list of the existing associations (if it exists) otherwhise display a message: "The scheduler is empty";
	- Add a button at the top of the page "Schedule";
	- Add a modal bootstrap in the page;
		Resource: https://getbootstrap.com/docs/4.0/components/modal/
	- Add all the dropdowns needed;
	- Add a "Close" button that will close the modal:
	- Add a "Plan" button that will call an ajax function in order to save the Scheduling calling a function in the same controller or in the APIs.
	- Display a message for success or failure then close the modal after 3.5 seconds (3500 milliseconds).

3. Stylize the page with a css in a separate file after the bootstrap script. All your css class names have to start with "course-"; e.g. "course-container", "course-button", etc..
	Resource: http://api.jquery.com/category/css/
			  https://getbootstrap.com/docs/4.0/components/
3.a Create a navigation Menù to connect all the relevant pages.

4. There are more then one bug in the application, find them and keep note of them. 
	- Solve them.

5. Provide some log informations:
	One Table called LogDefinition:
	 - UidLog uniqueidentifier
	 - LogAction nvarchar(100)
	 - LogSeverity nvarchar(100)
	 - LogMessage nvarchar(max)

	That has to match an object with those fields:
	 - UidLog as Guid
	 - LogAction as Enum
	 - LogSeverity as Enum
	 - LogMessage as string

5.a you can use stored procedure to insert the log or the WebApi
5.b you can create a monitor to see the logs and filter by Action or Severity
# PaymentGateway

● How to run your solution. 

I will send to you a GitHub link where you can find the repository of this project. All you need to do is to Download it, open it on Visual studio and run it. After the application starts and the web page is open, it is possible to test the api. To make it easier I implemented Swagger. So, you only have to put the "/swagger" in the end of the url and it will open all the documentation and an easy way to try the app. 

● Any assumptions you made.

For the CKO bank simulator, I only created a class that will always return success when you try to make a payment. If the CKO bank really existed, it was necessary to map the paymentRequest to the object that CKOBank would receive, and create a call to CKO bank, then, map the response to the one that we needed. 

● Areas for improvement. 

Some areas to improve is CKO bank, I really wanted to create a new solution for CKO bank in order to simulate everything like it is a real bank, but I didn't have the time. Another thing that needs improvement is the deployment of the application, I was not able to do it, I only deployed the database in order to be easier to test. As I never deployed anything from scratch (create all the configurations, and pipelines and so on, I needed to learn it, but because of the time, even when I tried, the deployment was always going wrong unfortunately.Other things that need to be done if this was a real application, it is the mask of the passwords and the replacement of all the appSettings values. Also, the documentation, I didn't create any file of documentation with diagrams and US's and the explanation of how the logics and the program works, I think it was needed right? However it is a good thing to have.

● What cloud technologies you’d use and why  

To deploy the database I used azure, because it is the one that I have an account and was able to try for free. In my master degree I already deployed databases and applications on Heroku that were free, and in the beginning I tried to do it for this application, however, now the deployment of the database is paid there. So I moved to azure. Is one that I am familiar with, even if I never deployed anything from scratch there. 

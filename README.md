Post on this lecture (Week 1): https://gvsucomputingclub.com/posts/Getting%20Started%20with%20.NET%20Core/


1. After we move the WeatherForecast class to Models, lets create our own controllers and models. First we will create a `CISClass.cs` class

2. Now lets create our controller `CISClassController.cs`. We can just copy the `WeatherForecastController.cs`. Lets create a constructor holding some dumby data and some GET request for this data. 

3. We should try to change some of the routing. It's pretty simple.

4. Lets make a POST request. This creates a new entry (Lets have it return the current state).

5. You will notice that the data isn't being updated. This is because the constructor we created is being called everytime you make a call. So what we actually need to do is create a seperate class to connect to a database to do this. We will be doing this next week.

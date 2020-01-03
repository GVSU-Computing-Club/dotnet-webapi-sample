1. After we move the WeatherForecast class to Models, lets create our own controllers and models. First we will create a `CISClass.cs` class

2. Now lets create our controller `CISClassController.cs`. We can just copy the `WeatherForecastController.cs`. Lets create a constructor holding some dumby data and some GET request for this data. 

3. Lets make a POST request. This creates a new entry (Lets have it return the current state).

4. You will notice that the data isn't being updated. This is because the constructor we created is being called everytime you make a call. So what we actually need to do is create a seperate class for the data.     


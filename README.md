# ThermoTrack
Real time temperature monitoring system
 <blockquote class="text-justify">
        <span style="font-size:x-large;">Thermo Track</span> offers a most effectual remote temperature monitoring system built using .Net technology.
        This system offers a current temperature reading of the Thermo Track Sensor, which usually transmits data for every 2 seconds along with
        time-series graphical view for temperature with minumum, maximum and average temperature values calculated for the last 20 readings on the dashboard.
 </blockquote>

### Technologies Used:

1) ASP.Net MVC 5 (for display of Sensor real time data)
2) SignalR
3) Console Application (acts a Sensor which generates temperature between 10 to 50 and transmits for every 2 seconds)
4) JQuery

### SETUP
1) After pulling the code from git to your local machine. Open the solution in the Visual Studio.
2) Now right click on solution and select **`Set Startup Projects`** as below.
![solution right click](https://user-images.githubusercontent.com/27807217/51087050-240d3000-1774-11e9-8ba4-45e1de521360.png)
3) In the opened dialog select **`Multiple Startup Projects`** radio button and choose **`Start`** form the Action column against both the projects and click **`Apply`** and **`OK`** buttons.
![startup projects](https://user-images.githubusercontent.com/27807217/51087078-63d41780-1774-11e9-8035-82e7a132a4c0.png)
4) Now both the projects are set as Startup Projects and now try to Build and Run the application.

### ScreenShot
![Dashboard](https://user-images.githubusercontent.com/27807217/51086385-5024b300-176c-11e9-97de-b4640575e640.jpg)

### NOTE
### This application is best viewed in Google Chrome

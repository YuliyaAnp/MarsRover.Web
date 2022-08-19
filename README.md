# MarsRover.Web

This is a solution for the Mars Rover Kata where multiple rovers can be deployed to the Mars plateau. 
Basic UI demonstrates the starting and finishing position of the rovers. 

Solution was implemented in VS2022 using .NET Core 6.0.

#How to run
1. Application is deployed to Azure:
https://marsrover19082022.azurewebsites.net/
2. Alternatively it can be run in VS locally by F5.

#How to use the app
1. Prepare local input csv in the following format:
1 2 N|LMLMLMLMM
3 3 E|MMRMM

2. Click the Load button and select the csv on your local computer.
Initial states of the rovers will be displayed on the grid.

3. Click the Run button to calculate the end state for all the rovers.

#Scenarios
1. One rover/multiple rovers are deployed to the plateau
2. Invalid input when multiple rovers are deployed to the same cell
3. Rover reaches end of grid
4. Rover bumps into another rover

#Notes 
1. Start and Finish cells are colour coded and the legend is above the grid.
2. Direction is specified by Arrows. The compas (legend) is displayed under the grid. 
3. After loading and running one csv another csv can be uploaded straight away. 
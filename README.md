# Remote SR-22 GCU panel for X-plane 11 with Torquesim SR-22 plugin

This is the remote Cirrus SR-22 panel for [Torquesim SR-22 plugin](https://torquesim.com/sr22/index.html) of X-plane 11. 
Panel app can run on the same computer as X-plane but the separate computer with touchscreen works best.

![Screenshot](images/screenshot.jpg)

There are two control buttons at the bottom left corner of the panel.

![Highlight button](images/highlight-button.png) Highlight button shows the areas of the control panel that can be pressed. 
Some panel buttons are not active and invisible buttons near knobs are used to turn them clockwise and counter-clockwise.
![Highlighted panel buttons](images/screenshot-highlighted.jpg)

![Connection button](images/connection-button.png) Connection button opens the X-plane connection window. 
X-Plane network tab of the settings window shows the IP address that should be entered here. The default port usually works fine.
![Connection window](images/connection-window.png)

These connection settings are saved to the file. The next time app runs it loads connection settings from the file but the app 
does not connect to the X-Plane automatically. You would still have to open the connection winow and click on the "connect" button.


## Building and running the app

It is a .net core 3.1 windows 10 app which you can build and run easily by following these steps:
* Install [.net core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1) if it is not yet installed. Click on SDK windows x64 installer link to download and install the framework.
* Clone this repo by running `git clone https://github.com/pilotpocket/x-plane-sr22-gcu.git` command.
* Go to the **src/SR22gcu** folder in the cloned repo and execute `dotnet run` command line to build and run the app. 

Used libraries/packages:
* The app contains code from [X-Plane connector](https://github.com/MaxFerretti/XPlaneConnector) for communications with X-Plane simulator.
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) nuget package is used for storing the conection settings.


## Running the app without building

Sorry. Not at this time. If .net core framework is installed on the system then compiled app is just 4Mb which is fine. 
However, with everything included the app is over 200Mb which seems just too big. It just makes more sense to install the .net core 3.1 
and build the app yourself.


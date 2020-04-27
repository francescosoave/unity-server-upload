# unity-server-upload
script to upload data from unity to server

To use:

## --- server side

1) You need a website up and running. That means a domain + hosting service. You don't need any "actual" website frontend. There are free options (search free hosting) or paid plans. Beware free options might have some limitations etc
2) Once you have your website running, from your hosting profile, go in your control panel (likely cPanel or Plesk). From here you have to go in your File Manager.
3) In the FileManager you'll see a list of folders. You should have a httpdoc folder.
4) Create a folder inside your httpdoc folder. Call it whatever you like (let's say we call it "test").
5) Inside your new "test" folder, add the getFile.php file.
4) Now, while still inside your "test" folder, create a new folder called "data".
5) Your tree should be:
- httpdoc
- - test
- - - data
- - - getFile.php

6) note that the getFile.php is at the address: http://www.yourwebsitename.domain/test/getFile.php
7) if you go to this address now you should see a white screen with the "FILE NOT OK" being displayed in the top left corner. If you see it good. If you don't, double check the previous steps.

## --- unity side

1) Create an empty component, call it DataUploader and attach the DataUploader.cs to it
2) Create another empty component, call it whatever you like (let's say we call it "Controller") and attach the Controller.cs script to it
3) Once you have implemented your InputManager component/class you should be able to easily link it to the controller

## -- extra notes

1) I do have a InputManager component with a InputManager class attached to it, which deals with button presses. I call it in the Update() method of the Controller class
2) I do have a DataWriter class that writes my csv file, saves it locally. Therefore in the DataUploader class I am loading that .csv file
3) I have a custom class called StaticData which contains (unsurprisingly) static stuff. This includes the current computer unique ID (Systeminfo.DeviceUniqueID) which is used in the DataUploader class. This is how I identify the machine which uploads the data and prevent infinite uploads

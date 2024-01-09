# Payload-Generator
An aggressor script that can help automate payload building in Cobalt Strike

### Requirements
Visual Studio 2022 with .NET Framework 4.8

## Usage
The aggressor will only work in a predetermined path which is ```C:\Tools\cobaltstrike\aggressors\PG```, When adding the new aggressor script a new menu button would be added to Cobalt Strikes Menu Bar

![image](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/ae8c83c4-b9a4-44e8-bd59-3601e51ec13e)

The aggressor scripts basically automates payload creation, in this example a C# binary with the CreateThread API will be compiled

![image](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/6d18dcc6-6b6f-47fa-bd83-ed2b59e15bca)

For building the payload, predetermined values are already added to the Menu options as this API only works with x86 binaries, and the assembly type is winexe to avoid a console popup

![image](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/bf5b1a92-d897-4836-8522-78bac5c20d25)

Adding more templates is easy by editing the PG.cna file and placing the new scripts in the ```/scripts/``` folder you can see below that there is a comment highlighting how to add a new menu

![image](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/3cb5c9ca-cc9e-4f48-abc2-8d8505019674)

As shown below we see that it requires the C# Project file to create these binaries as it is being automated by compiling with MSBUILD, I tried adding this with Linux but no success, you are more than free to change this and add more features but these default ones are working for me.

![image](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/8a3d3540-339e-4a16-8df1-f9a26d43aabc)

This sample payload will get detected by AV. I do recommend adding this path to your exclusions or working with an OS such as COMMANDO VM to avoid any issues. This is running on my Windows 11 Home workstation with an exclusion on this path with no issues. Some small features, such as random variable naming, were added, but other things have been hardcoded as this is intended to be a POC Aggressor. I do recommend checking out the reference to get a deeper look at the building and adding more payloads.

###Demo

![Payload Generator](https://github.com/Workingdaturah/Payload-Generator/assets/69986028/00ebcf80-c0a3-46c0-b771-ee49cf345f51)




### Reference
https://github.com/offsecginger/AggressorScripts

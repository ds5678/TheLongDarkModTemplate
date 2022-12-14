# The Long Dark Mod Template

This is a coding mod template for The Long Dark by Hinterland Games.

## Instructions

* Download [this folder](https://download-directory.github.io/?url=https%3A%2F%2Fgithub.com%2Fds5678%2FTheLongDarkModTemplate%2Ftree%2Fmain%2FModTemplate).
* Open `ModTemplate.csproj` in NotePad and change the path for The Long Dark.
* Rename `ModTemplate.csproj` to the name of the mod.
* Install [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
* Install [Visual Studio](https://visualstudio.microsoft.com/vs/community/).
* Run Visual Studio. Click on `Open a project or solution`. Select the renamed `ModTemplate.csproj` file.
* Create a new class and inherit it from `MelonLoader.MelonMod`.
* Edit `AssemblyInfo.cs` with your mod details.
* In the `Build` menu, click on `Build Solution`.
* If compilation succeeds, your mod will be in a sub folder, typically `bin/Debug/net6.0/` or `bin/Release/net6.0`.
* Copy the compiled mod to your `Mods` folder and run the game.

## Additional Notes

* Release builds run faster than Debug builds, but Debug builds show better stack traces when an error occurs.
* If at any point, Visual Studio asks where to save the solution, save it next to the `csproj` file.
* If you have duplicate mods in your `Mods` folder, MelonLoader will error.

## Disclaimer

Do not post issues asking how to use this. There are Discord servers for asking these kinds of questions:

* [The Long Dark Modding](https://discord.gg/2mnXAZfGXQ)
* [MelonLoader](https://discord.gg/2Wn3N2P)

Do not ping me on Discord either, especially not in direct messages.

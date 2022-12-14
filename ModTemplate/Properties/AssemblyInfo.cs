using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;

//This is a C# comment. Comments have no impact on compilation.

//ModName, ModVersion, ModAuthor, and ModNamespace.ModClassInheritingFromMelonMod all need changed.

[assembly: AssemblyTitle("ModName")]
[assembly: AssemblyCopyright("Created by ModAuthor")]

//Version numbers in C# are a set of 1 to 4 positive integers separated by periods.
//Mods typically use 3 numbers. For example: 1.2.1
//The mod version need specified in three places.
[assembly: AssemblyVersion("ModVersion")]
[assembly: AssemblyFileVersion("ModVersion")]
[assembly: MelonInfo(typeof(ModNamespace.ModClassInheritingFromMelonMod), "ModName", "ModVersion", "ModAuthor", null)]

//This tells MelonLoader that the mod is only for The Long Dark.
[assembly: MelonGame("Hinterland", "TheLongDark")]
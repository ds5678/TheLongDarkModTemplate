using System.CodeDom.Compiler;

internal class Program
{
	private const string PathToRepositoryRoot = "../../../../";
	private const string TemplateProjectDirectory = PathToRepositoryRoot + "ModTemplate/";
	private const string PropertiesFolder = TemplateProjectDirectory + "Properties/";
	private const string AssemblyInfoFile = PropertiesFolder + "AssemblyInfo.cs";
	private const string OutputFile = TemplateProjectDirectory + "ModTemplate.csproj";
	private const string AssemblyInfoContent = """
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
		""";

	private static void Main(string[] args)
	{
		Directory.CreateDirectory(TemplateProjectDirectory);
		WriteCsProjFile(args[0]);
		Directory.CreateDirectory(PropertiesFolder);
		File.WriteAllText(AssemblyInfoFile, AssemblyInfoContent);
		Console.WriteLine("Done!");
	}

	private static void WriteCsProjFile(string pathToGameFolder)
	{
		StreamWriter streamWriter = new StreamWriter(OutputFile, false);
		streamWriter.NewLine = "\n";
		IndentedTextWriter writer = new IndentedTextWriter(streamWriter);
		writer.NewLine = "\n";
		WriteCsProjFile(writer, pathToGameFolder);
		writer.Flush();
		streamWriter.Flush();
	}

	private static void WriteCsProjFile(IndentedTextWriter writer, string pathToGameFolder)
	{
		using (new ProjectSdk(writer))
		{
			writer.WriteLine("<!--This is an xml comment. Comments have no impact on compiling.-->");
			writer.WriteLineNoTabs(null);
			using (new PropertyGroup(writer))
			{
				writer.WriteLine("<!--This needs to be changed for the mod to compile.-->");
				writer.WriteLine(@"<TheLongDarkPath>C:\Path\To\TLD_GameFolder</TheLongDarkPath>");
			}
			writer.WriteLineNoTabs(null);
			using (new PropertyGroup(writer))
			{
				writer.WriteLine("<!--This is the .NET version the mod will be compiled with. Don't change it.-->");
				writer.WriteLine("<TargetFramework>net6.0</TargetFramework>");
				writer.WriteLineNoTabs(null);
				writer.WriteLine("<!--This tells the compiler to use the latest C# version.-->");
				writer.WriteLine("<LangVersion>Latest</LangVersion>");
				writer.WriteLineNoTabs(null);
				writer.WriteLine("<!--This adds global usings for a few common System namespaces.-->");
				writer.WriteLine("<ImplicitUsings>enable</ImplicitUsings>");
				writer.WriteLineNoTabs(null);
				writer.WriteLine("<!--This enables nullable annotation and analysis. It's good coding form.-->");
				writer.WriteLine("<Nullable>enable</Nullable>");
				writer.WriteLineNoTabs(null);
				writer.WriteLine("<!--This tells the compiler to use assembly attributes instead of generating its own.-->");
				writer.WriteLine("<GenerateAssemblyInfo>false</GenerateAssemblyInfo>");
				writer.WriteLineNoTabs(null);
				writer.WriteLine("<!--PDB files are mostly useless for modding since they can't be loaded.-->");
				writer.WriteLine("<DebugType>none</DebugType>");
			}
			writer.WriteLineNoTabs(null);
			writer.WriteLine("<!--This tells the compiler where to look for assemblies. Don't change it.-->");
			using (new PropertyGroup(writer))
			{
				writer.WriteLine("<MelonLoaderPath>$(TheLongDarkPath)/MelonLoader/net6</MelonLoaderPath>");
				writer.WriteLine("<ManagedPath>$(TheLongDarkPath)/MelonLoader/Managed</ManagedPath>");
				writer.WriteLine("<Il2CppPath>$(TheLongDarkPath)/MelonLoader/Il2CppAssemblies</Il2CppPath>");
				writer.WriteLine("<ModsPath>$(TheLongDarkPath)/Mods</ModsPath>");
				writer.WriteLine("<AssemblySearchPaths>$(AssemblySearchPaths);$(MelonLoaderPath);$(ManagedPath);$(Il2CppPath);$(ModsPath);</AssemblySearchPaths>");
			}
			writer.WriteLineNoTabs(null);
			writer.WriteLine("<!--This tells the compiler to not include referenced assemblies in the output folder.-->");
			using (new ItemDefinitionGroup(writer))
			{
				writer.WriteLine("<Reference>");
				writer.Indent++;
				writer.WriteLine("<Private>False</Private>");
				writer.WriteLine("<SpecificVersion>False</SpecificVersion>");
				writer.Indent--;
				writer.WriteLine("</Reference>");
			}
			writer.WriteLineNoTabs(null);
			writer.WriteLine("<!--This is the list of assemblies that the mod references. Most of these are unnecessary for normal mods, but are included here for completeness.-->");
			using (new ItemGroup(writer))
			{
				foreach (string assemblyName in GetAssemblyNames(pathToGameFolder))
				{
					writer.WriteLine($"""<Reference Include="{assemblyName}"/>""");
				}
			}
		}
	}

	private static IEnumerable<string> GetAssemblyNames(string pathToGameFolder)
	{
		yield return "MelonLoader";
		yield return "0Harmony";
		yield return "AssetRipper.VersionUtilities";
		yield return "AssetsTools.NET";
		yield return "Il2CppInterop.Common";
		yield return "Il2CppInterop.Runtime";
		yield return "Tomlet";
		foreach (string path in Directory.EnumerateFiles(Path.Combine(pathToGameFolder, "MelonLoader", "Il2CppAssemblies"), "*.dll"))
		{
			yield return Path.GetFileNameWithoutExtension(path);
		}
		yield return "UnityEngine.Il2CppAssetBundleManager";
		yield return "UnityEngine.Il2CppImageConversionManager";
	}
}

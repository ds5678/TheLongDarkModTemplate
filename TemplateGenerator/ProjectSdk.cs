using System.CodeDom.Compiler;

internal readonly struct ProjectSdk : IDisposable
{
	private readonly IndentedTextWriter writer;
	public ProjectSdk() => throw new NotSupportedException();
	public ProjectSdk(IndentedTextWriter writer)
	{
		this.writer = writer;
		writer.WriteLine("""<Project Sdk="Microsoft.NET.Sdk">""");
		writer.Indent++;
	}

	public void Dispose()
	{
		writer.Indent--;
		writer.WriteLine("</Project>");
	}
}

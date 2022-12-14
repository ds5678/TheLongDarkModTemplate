using System.CodeDom.Compiler;

internal readonly struct PropertyGroup : IDisposable
{
	private readonly IndentedTextWriter writer;
	public PropertyGroup() => throw new NotSupportedException();
	public PropertyGroup(IndentedTextWriter writer)
	{
		this.writer = writer;
		writer.WriteLine("<PropertyGroup>");
		writer.Indent++;
	}

	public void Dispose()
	{
		writer.Indent--;
		writer.WriteLine("</PropertyGroup>");
	}
}

using System.CodeDom.Compiler;

internal readonly struct ItemGroup : IDisposable
{
	private readonly IndentedTextWriter writer;
	public ItemGroup() => throw new NotSupportedException();
	public ItemGroup(IndentedTextWriter writer)
	{
		this.writer = writer;
		writer.WriteLine("<ItemGroup>");
		writer.Indent++;
	}

	public void Dispose()
	{
		writer.Indent--;
		writer.WriteLine("</ItemGroup>");
	}
}

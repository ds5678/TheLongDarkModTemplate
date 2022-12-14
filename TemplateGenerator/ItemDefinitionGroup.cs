using System.CodeDom.Compiler;

internal readonly struct ItemDefinitionGroup : IDisposable
{
	private readonly IndentedTextWriter writer;
	public ItemDefinitionGroup() => throw new NotSupportedException();
	public ItemDefinitionGroup(IndentedTextWriter writer)
	{
		this.writer = writer;
		writer.WriteLine("<ItemDefinitionGroup>");
		writer.Indent++;
	}

	public void Dispose()
	{
		writer.Indent--;
		writer.WriteLine("</ItemDefinitionGroup>");
	}
}
namespace TypescriptSyntaxPaste.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cScript = @"class Foo{}";
            CSharpToTypescriptConverter csharpToTypescriptConverter = new CSharpToTypescriptConverter();
            var typescript = csharpToTypescriptConverter.ConvertToTypescript(cScript);

            System.Console.WriteLine(typescript);
        }
    }
}

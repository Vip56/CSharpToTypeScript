using Microsoft.CodeAnalysis;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class CSharpSyntaxTranslation : SyntaxTranslation
    {
        public CSharpSyntaxTranslation() { }
        public CSharpSyntaxTranslation(SyntaxNode syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class NameTranslation : TypeTranslation
    {
        public NameTranslation() { }

        public NameTranslation(NameSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }
    }
}

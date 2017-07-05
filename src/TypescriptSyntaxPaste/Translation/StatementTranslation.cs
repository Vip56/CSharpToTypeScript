using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class StatementTranslation : CSharpSyntaxTranslation
    {
        public StatementTranslation()
        {
        }

        public StatementTranslation(StatementSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }
    }
}

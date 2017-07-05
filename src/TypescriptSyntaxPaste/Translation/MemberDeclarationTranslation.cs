using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class MemberDeclarationTranslation : CSharpSyntaxTranslation
    {
        public MemberDeclarationTranslation() { }
        public MemberDeclarationTranslation(MemberDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {

        }
    }
}

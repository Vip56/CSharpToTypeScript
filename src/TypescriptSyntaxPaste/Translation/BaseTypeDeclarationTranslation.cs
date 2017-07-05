using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypescriptSyntaxPaste.Patch;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class BaseTypeDeclarationTranslation : MemberDeclarationTranslation
    {
        public BaseTypeDeclarationTranslation() { }

        public BaseTypeDeclarationTranslation(BaseTypeDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Modifiers = syntax.Modifiers.Get(this);
            AttributeList = syntax.AttributeLists.Get<AttributeListSyntax, AttributeListTranslation>(this);
        }

        public SyntaxTokenListTranslation Modifiers { get; set; }

        public SyntaxListTranslation<AttributeListSyntax, AttributeListTranslation> AttributeList { get; set; }

        public override void ApplyPatch()
        {
            InnerTypeDeclarationPatch innerTypeDeclarationPatch = new InnerTypeDeclarationPatch();
            innerTypeDeclarationPatch.Apply(this);
            base.ApplyPatch();
        }
    }
}

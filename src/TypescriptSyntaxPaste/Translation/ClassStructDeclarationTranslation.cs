using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class ClassStructDeclarationTranslation : TypeDeclarationTranslation
    {
        public ClassStructDeclarationTranslation(TypeDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            if (syntax.BaseList != null)
            {
                BaseList = syntax.BaseList.Get<BaseListTranslation>(this);
            }
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
        }

        public BaseListTranslation BaseList { get; set; }

        public bool HasExplicitBase()
        {
            if (Syntax.BaseList == null)
            {
                return false;
            }

            return BaseList.GetBaseClass() != null;
        }
    }
}

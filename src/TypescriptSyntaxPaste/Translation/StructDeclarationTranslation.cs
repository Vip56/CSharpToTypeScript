using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypescriptSyntaxPaste.Contract;

namespace TypescriptSyntaxPaste.Translation
{
    public class StructDeclarationTranslation : ClassStructDeclarationTranslation, IBaseExtended
    {
        public new StructDeclarationSyntax Syntax
        {
            get { return (StructDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public StructDeclarationTranslation(StructDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            if (BaseList == null)
            {
                BaseList = new BaseListTranslation();
                BaseList.Parent = this;
                BaseList.Types = new SeparatedSyntaxListTranslation<BaseTypeSyntax, BaseTypeTranslation>();
                BaseList.Types.Parent = BaseList;
            }
        }


        public override void ApplyPatch()
        {
            base.ApplyPatch();
        }

        protected override string InnerTranslate()
        {
            string baseTranslation = BaseList?.Translate();

            return $@"{GetAttributeList()}export class {Syntax.Identifier}{TypeParameterList?.Translate()} {baseTranslation}
                {{
                {Members.Translate()} 
                }}";
        }
    }
}

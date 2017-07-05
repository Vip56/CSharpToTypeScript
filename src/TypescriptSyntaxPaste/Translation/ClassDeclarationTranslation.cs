using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using TypescriptSyntaxPaste.Contract;

namespace TypescriptSyntaxPaste.Translation
{
    public class ClassDeclarationTranslation : ClassStructDeclarationTranslation, IBaseExtended
    {
        public new ClassDeclarationSyntax Syntax
        {
            get { return (ClassDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ClassDeclarationTranslation(ClassDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            var constructor = Members.GetEnumerable<ConstructorDeclarationTranslation>().FirstOrDefault();
            if (constructor == null)
            {
                return;
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

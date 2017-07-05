using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public class TypeParameterConstraintTranslation : CSharpSyntaxTranslation
    {
        public new TypeParameterConstraintSyntax Syntax
        {
            get { return (TypeParameterConstraintSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public TypeParameterConstraintTranslation() { }
        public TypeParameterConstraintTranslation(TypeParameterConstraintSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {

        }

        protected override string InnerTranslate()
        {
            return Syntax.ToString();
        }
    }
}

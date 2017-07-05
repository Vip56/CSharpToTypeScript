using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public class BaseTypeTranslation : CSharpSyntaxTranslation
    {
        public new BaseTypeSyntax Syntax
        {
            get { return (BaseTypeSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public BaseTypeTranslation() { }

        public BaseTypeTranslation(BaseTypeSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Type = syntax.Type.Get<TypeTranslation>(this);
        }

        public TypeTranslation Type { get; set; }

        protected override string InnerTranslate()
        {
            return Type.ToString();
        }
    }
}

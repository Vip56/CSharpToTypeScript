using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public class TypeArgumentListTranslation : CSharpSyntaxTranslation
    {
        public new TypeArgumentListSyntax Syntax
        {
            get { return (TypeArgumentListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public TypeArgumentListTranslation() { }
        public TypeArgumentListTranslation(TypeArgumentListSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Arguments = syntax.Arguments.Get<TypeSyntax, TypeTranslation>(this);
        }

        public SeparatedSyntaxListTranslation<TypeSyntax, TypeTranslation> Arguments { get; set; }

        protected override string InnerTranslate()
        {
            return $"<{Arguments.Translate()}> ";
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class TypeTranslation : ExpressionTranslation
    {
        public TypeTranslation() { }
        public TypeTranslation(TypeSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }

        public bool ActAsTypeParameter { get; set; }

        public virtual bool IsPrimitive
        {
            get { return false; }
        }

        public virtual string GetTypeIgnoreGeneric()
        {
            return this.Translate();
        }
    }
}

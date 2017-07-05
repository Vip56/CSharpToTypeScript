using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public class EqualsValueClauseTranslation : CSharpSyntaxTranslation
    {
        public new EqualsValueClauseSyntax Syntax
        {
            get { return (EqualsValueClauseSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public ExpressionTranslation Value { get; set; }

        public EqualsValueClauseTranslation(EqualsValueClauseSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Value = syntax.Value.Get<ExpressionTranslation>(this);
        }

        public override void ApplyPatch()
        {
            base.ApplyPatch();
            Helper.ApplyFunctionBindToCorrectContext(this.Value);
        }

        protected override string InnerTranslate()
        {
            var expr = Value.Translate();

            return string.Format("= {0}", expr);
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public class ParameterListTranslation : CSharpSyntaxTranslation
    {
        public new ParameterListSyntax Syntax
        {
            get { return (ParameterListSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public SeparatedSyntaxListTranslation<ParameterSyntax, ParameterTranslation> Parameters { get; set; }

        public ParameterListTranslation() { }

        public ParameterListTranslation(ParameterListSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            Parameters = syntax.Parameters.Get<ParameterSyntax, ParameterTranslation>(this);
        }

        private bool excludeDefaultValue;

        public bool ExcludeDefaultValue
        {
            get { return excludeDefaultValue; }
            set
            {
                excludeDefaultValue = value;
                foreach (var item in Parameters.GetEnumerable())
                {
                    item.ExcludeDefaultValue = value;

                }
            }
        }

        protected override string InnerTranslate()
        {
            return $"({Parameters.Translate()})";
        }

    }
}

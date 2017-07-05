using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.VirtualTranslation
{
    public class BaseFunctionGenericNameTranslation : GenericNameTranslation
    {
        protected GenericNameTranslation genericNameTranslation;

        public BaseFunctionGenericNameTranslation(GenericNameTranslation genericNameTranslation)
        {
            this.genericNameTranslation = genericNameTranslation;
            this.Parent = genericNameTranslation.Parent;
        }

        public SeparatedSyntaxListTranslation<TypeSyntax, TypeTranslation> Arguments { get; set; }
        public TypeTranslation ReturnType { get; set; }

        protected string GetFakeParamName(string previous)
        {
            return (previous ?? "") + "_";
        }
    }
}

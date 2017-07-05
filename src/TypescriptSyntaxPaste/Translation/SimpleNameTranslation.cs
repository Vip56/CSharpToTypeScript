using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class SimpleNameTranslation : NameTranslation
    {
        public SimpleNameTranslation() { }
        public SimpleNameTranslation(SimpleNameSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
        }

        public bool DetectApplyThis { get; set; } = true;


        protected string HandleApplyStaticOrThis(string syntaxStr)
        {
            SemanticModel semanticModel = GetSemanticModel();
            if (semanticModel == null)
            {
                return null;
            }

            SymbolInfo symbolInfo = semanticModel.GetSymbolInfo(Syntax);

            if (symbolInfo.Symbol != null && (
                symbolInfo.Symbol.Kind == SymbolKind.Field
                || symbolInfo.Symbol.Kind == SymbolKind.Property
                || symbolInfo.Symbol.Kind == SymbolKind.Method))
            {
                var result = Helper.ApplyThis(semanticModel, this, syntaxStr);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

    }
}

using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.Contract
{
    public interface ITranslationVisitor
    {
        void Visit(SyntaxTranslation translation);
    }
}

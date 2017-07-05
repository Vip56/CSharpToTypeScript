using System.Linq;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.VirtualTranslation.Delegates
{
    public class ComparisonGenericNameTranslation : BaseFunctionGenericNameTranslation
    {
        public ComparisonGenericNameTranslation(GenericNameTranslation genericNameTranslation) : base(genericNameTranslation)
        {
        }

        protected override string InnerTranslate()
        {
            var firstParam = genericNameTranslation.TypeArgumentList.Arguments.GetEnumerable().First();
            string firstParamStr = firstParam.Translate();
            return $"(_:{firstParamStr}, __:{firstParamStr})=> number";
        }
    }
}

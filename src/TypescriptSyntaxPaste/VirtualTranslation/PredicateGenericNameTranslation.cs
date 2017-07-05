using System.Linq;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.VirtualTranslation
{
    public class PredicateGenericNameTranslation : BaseFunctionGenericNameTranslation
    {
        public PredicateGenericNameTranslation(GenericNameTranslation genericNameTranslation) : base(genericNameTranslation)
        {
        }

        protected override string InnerTranslate()
        {
            var firstParam = genericNameTranslation.TypeArgumentList.Arguments.GetEnumerable().First();
            return $"(_:{firstParam.Translate()})=>boolean";
        }
    }
}

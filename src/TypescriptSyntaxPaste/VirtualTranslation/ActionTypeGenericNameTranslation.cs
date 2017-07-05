using System.Collections.Generic;
using System.Linq;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.VirtualTranslation
{
    public class ActionTypeGenericNameTranslation : BaseFunctionGenericNameTranslation
    {
        public ActionTypeGenericNameTranslation(GenericNameTranslation genericNameTranslation) : base(genericNameTranslation)
        {
            Arguments = genericNameTranslation.TypeArgumentList.Arguments;
            Attach();
        }

        protected override string InnerTranslate()
        {
            List<string> list = new List<string>();
            string name = "";
            list = Arguments.GetEnumerable().Select(f => $"{name = GetFakeParamName(name)}:{f.Translate()}").ToList();
            return $"({string.Join(",", list)}) => void";
        }
    }
}

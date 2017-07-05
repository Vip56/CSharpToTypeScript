using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypescriptSyntaxPaste.Translation
{
    public class GenericNameTranslation : SimpleNameTranslation
    {
        public new GenericNameSyntax Syntax
        {
            get { return (GenericNameSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public GenericNameTranslation() { }
        public GenericNameTranslation(GenericNameSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            TypeArgumentList = syntax.TypeArgumentList.Get<TypeArgumentListTranslation>(this);
            string name = syntax.Identifier.ToString();
            switch (name)
            {
                case "Func":
                    Func = new FunctionTypeGenericNameTranslation(this);
                    break;
                case "Predicate":
                    Func = new PredicateGenericNameTranslation(this);
                    break;
                case "Action":
                    Func = new ActionTypeGenericNameTranslation(this);
                    break;
                case "Comparison":
                    Func = new ComparisonGenericNameTranslation(this);
                    break;
            }

        }

        public TypeArgumentListTranslation TypeArgumentList { get; set; }
        public BaseFunctionGenericNameTranslation Func { get; set; }

        public bool ExcludeTypeParameter { get; set; }

        public override string GetTypeIgnoreGeneric()
        {
            return Syntax.Identifier.ToString();
        }

        protected override string InnerTranslate()
        {
            if (!DetectApplyThis)
            {
                return NormalTranslate();
            }

            if (Func != null)
            {
                return Func.Translate();
            }

            return NormalTranslate();
        }


        protected string NormalTranslate(bool excludeTypeParameter = false)
        {
            string strIdentifier = Syntax.Identifier.ToString();

            if (ExcludeTypeParameter || excludeTypeParameter)
            {
                return $"{strIdentifier}";
            }

            return $"{strIdentifier}{TypeArgumentList.Translate()}";
        }
    }
}

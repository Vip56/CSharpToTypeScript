using System;
using System.Linq;
using TypescriptSyntaxPaste.Contract;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.Patch
{
    public class GenericConstrantsPatch : Patch
    {
        public void Apply(ITypeParameterConstraint typeDeclarationTranslation)
        {

            if (typeDeclarationTranslation.TypeParameterList == null)
            {
                return;
            }

            var parameters = typeDeclarationTranslation.TypeParameterList.Parameters.GetEnumerable();
            foreach (TypeParameterTranslation item in parameters)
            {
                var foundClause = typeDeclarationTranslation.ConstraintClauses
                    .GetEnumerable().FirstOrDefault(f => f.Name.Translate() == item.Syntax.Identifier.ToString());
                if (foundClause == null)
                {
                    continue;
                }

                var constraints = foundClause.Constraints.GetEnumerable().OfType<TypeConstraintTranslation>().ToArray();
                if (!constraints.Any())
                {
                    continue;
                }

                if (constraints.Length > 1)
                {
                    throw new NotSupportedException("not support multiple constrants");
                }

                item.TypeConstraint = constraints[0].Type;
            }
        }
    }
}

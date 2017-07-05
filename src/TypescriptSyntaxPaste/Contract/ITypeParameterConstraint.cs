using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste.Contract
{
    public interface ITypeParameterConstraint
    {
        TypeParameterListTranslation TypeParameterList { get; set; }

        SyntaxListTranslation<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseTranslation> ConstraintClauses { get; set; }
    }
}

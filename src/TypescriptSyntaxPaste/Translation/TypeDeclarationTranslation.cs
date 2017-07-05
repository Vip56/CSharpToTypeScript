using Microsoft.CodeAnalysis.CSharp.Syntax;
using TypescriptSyntaxPaste.Contract;
using TypescriptSyntaxPaste.Patch;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class TypeDeclarationTranslation : BaseTypeDeclarationTranslation, ITypeParameterConstraint
    {
        public new TypeDeclarationSyntax Syntax
        {
            get { return (TypeDeclarationSyntax)base.Syntax; }
            set { base.Syntax = value; }
        }

        public TypeDeclarationTranslation(TypeDeclarationSyntax syntax, SyntaxTranslation parent) : base(syntax, parent)
        {
            TypeParameterList = syntax.TypeParameterList.Get<TypeParameterListTranslation>(this);
            Members = syntax.Members.Get<MemberDeclarationSyntax, MemberDeclarationTranslation>(this);
            ConstraintClauses = syntax.ConstraintClauses.Get<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseTranslation>(this);
        }

        public SyntaxListTranslation<MemberDeclarationSyntax, MemberDeclarationTranslation> Members { get; set; }

        public SyntaxListTranslation<TypeParameterConstraintClauseSyntax, TypeParameterConstraintClauseTranslation> ConstraintClauses { get; set; }

        public TypeParameterListTranslation TypeParameterList { get; set; }

        public TokenTranslation Identifier
        {
            get { return Syntax.Identifier.Get(this); }
        }

        public override void ApplyPatch()
        {
            GenericConstrantsPatch genericConstrantsPatch = new GenericConstrantsPatch();
            genericConstrantsPatch.Apply(this);
            base.ApplyPatch();
        }

        protected string GetAttributeList()
        {
            return Helper.GetAttributeList(Syntax.AttributeLists);
        }
    }
}

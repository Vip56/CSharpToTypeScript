using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TypescriptSyntaxPaste
{
    public class AddIPrefixInterfaceDeclaration
    {
        class AddIPrefixInterfaceDeclarationRewriter : CSharpSyntaxRewriter
        {
            public override SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
            {
                var name = node.Identifier.ValueText;
                if (name.StartsWith("I"))
                {
                    return base.VisitInterfaceDeclaration(node);
                }

                return node.ReplaceToken(node.Identifier, SyntaxFactory.ParseToken("I" + name));
            }
        }

        public static CSharpSyntaxNode AddIPrefix(CSharpSyntaxNode syntaxNode)
        {
            return (CSharpSyntaxNode)new AddIPrefixInterfaceDeclarationRewriter().Visit(syntaxNode);
        }
    }
}

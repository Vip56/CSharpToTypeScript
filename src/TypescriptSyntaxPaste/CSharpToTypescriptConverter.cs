using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using TypescriptSyntaxPaste.Translation;

namespace TypescriptSyntaxPaste
{
    public class CSharpToTypescriptConverter
    {
        private MetadataReference mscorlib;

        private MetadataReference Mscorlib
        {
            get
            {
                if (mscorlib == null)
                {
                    mscorlib = MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location);
                }
                return mscorlib;
            }
        }

        public string ConvertToTypescript(string text, ISettingStore settingStore = null)
        {
            if (settingStore == null)
                settingStore = new DefaultSettingStore();

            try
            {
                var tree = (CSharpSyntaxTree)CSharpSyntaxTree.ParseText(text);

                if(tree.GetDiagnostics().Any(f => f.Severity == DiagnosticSeverity.Error))
                {
                    return null;
                }

                var root = tree.GetRoot();

                if (IsEmptyRoot(root))
                    return null;

                if (settingStore.IsConvertToInterface)
                {
                    root = ClassToInterfaceReplacement.ReplaceClass(root);
                }

                if (settingStore.IsConvertMemberToCamelCase)
                {
                    root = MakeMemberCamelCase.Make(root);
                }

                if (settingStore.IsConvertListToArray)
                {
                    root = ListToArrayReplacement.ReplaceList(root);
                }

                if (settingStore.AddIPrefixInterfaceDeclaration)
                {
                    root = AddIPrefixInterfaceDeclaration.AddIPrefix(root);
                }

                if (settingStore.IsInterfaceOptionalProperties)
                {
                    root = OptionalInterfaceProperties.AddOptional(root);
                }

                tree = (CSharpSyntaxTree)root.SyntaxTree;

                var translationNode = TF.Get(root, null);

                var compilation = CSharpCompilation.Create("TemporaryCompilation",
                     syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
                var model = compilation.GetSemanticModel(tree);

                translationNode.Compilation = compilation;
                translationNode.SemanticModel = model;

                translationNode.ApplyPatch();
                return translationNode.Translate();
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        private bool IsEmptyRoot(SyntaxNode root)
        {
            return !root.DescendantNodes().Any();
        }
    }
}

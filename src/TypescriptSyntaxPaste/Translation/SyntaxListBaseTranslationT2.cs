using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TypescriptSyntaxPaste.Translation
{
    public abstract class SyntaxListBaseTranslation<T, ST> : SyntaxListBaseTranslation where T : SyntaxNode where ST : SyntaxTranslation
    {

        public SyntaxListBaseTranslation()
        { }

        public SyntaxListBaseTranslation(SyntaxTranslation parent) : base(parent)
        {

        }

        public IEnumerable<ST> GetEnumerable()
        {
            return SyntaxCollection.Select(f => (ST)f).ToArray();
        }

        public IEnumerable<TT> GetEnumerable<TT>() where TT : SyntaxTranslation
        {
            return SyntaxCollection.Where(f => f is TT).Select(f => (TT)f).ToArray();
        }
    }
}

using System;

namespace TypescriptSyntaxPaste
{
    public class DefaultSettingStore : ISettingStore
    {
        public bool AddIPrefixInterfaceDeclaration
        {
            get
            {
                return true;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsConvertListToArray
        {
            get
            {
                return true;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsConvertMemberToCamelCase
        {
            get
            {
                return false;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsConvertToInterface
        {
            get
            {
                return true;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsInterfaceOptionalProperties
        {
            get
            {
                return false;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

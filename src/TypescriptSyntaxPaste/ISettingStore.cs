namespace TypescriptSyntaxPaste
{
    public interface ISettingStore
    {
        bool AddIPrefixInterfaceDeclaration { get; set; }
        bool IsConvertListToArray { get; set; }
        bool IsConvertMemberToCamelCase { get; set; }
        bool IsConvertToInterface { get; set; }
        bool IsInterfaceOptionalProperties { get; set; }
    }
}

﻿// <auto-generated/>
#nullable enable

namespace LasMarias.WareHouse.Shared.Client
{
    /// <summary>
    /// Represents the operation service of the GetAttributes GraphQL operation
    /// <code>
    /// query GetAttributes {
    ///   attributes {
    ///     __typename
    ///     nodes {
    ///       __typename
    ///       value
    ///       attributeName {
    ///         __typename
    ///         name
    ///       }
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "12.7.0.0")]
    public partial class GetAttributesQueryDocument : global::StrawberryShake.IDocument
    {
        private GetAttributesQueryDocument()
        {
        }

        public static GetAttributesQueryDocument Instance { get; } = new GetAttributesQueryDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x71, 0x75, 0x65, 0x72, 0x79, 0x20, 0x47, 0x65, 0x74, 0x41, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x73, 0x20, 0x7b, 0x20, 0x61, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x6f, 0x64, 0x65, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x76, 0x61, 0x6c, 0x75, 0x65, 0x20, 0x61, 0x74, 0x74, 0x72, 0x69, 0x62, 0x75, 0x74, 0x65, 0x4e, 0x61, 0x6d, 0x65, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "8efc2d981e34412997a35e7d3e3267d8");
        public override global::System.String ToString()
        {
#if NETSTANDARD2_0
        return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
#else
            return global::System.Text.Encoding.UTF8.GetString(Body);
#endif
        }
    }
}

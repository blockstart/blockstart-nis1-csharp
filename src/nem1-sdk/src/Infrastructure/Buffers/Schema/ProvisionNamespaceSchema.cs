using System.Collections.Generic;
using io.nem1.sdk.Infrastructure.Buffers.SchemaHelpers;

namespace io.nem1.sdk.Infrastructure.Buffers.Schema
{
    internal class ProvisionNamespaceSchema : SchemaHelpers.Schema
    {
        internal ProvisionNamespaceSchema() : base(
            new List<SchemaAttribute> {
                new ScalarAttribute("transactionType", Constants.Value.SIZEOF_INT), // 1
                new ScalarAttribute("version", Constants.Value.SIZEOF_SHORT), // 2
                new ScalarAttribute("network", Constants.Value.SIZEOF_SHORT), // 3
                new ScalarAttribute("timestamp", Constants.Value.SIZEOF_INT), // 4
                new ScalarAttribute("publicKeyLen", Constants.Value.SIZEOF_INT), // 5
                new ArrayAttribute("publicKey", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("fee", Constants.Value.SIZEOF_LONG), // 7
                new ScalarAttribute("deadline", Constants.Value.SIZEOF_INT), // 8
                new ScalarAttribute("sinkAddressLength", Constants.Value.SIZEOF_INT), // 9
                new ArrayAttribute("sinkAddressString", Constants.Value.SIZEOF_BYTE), // 10
                new ScalarAttribute("rentalFee", Constants.Value.SIZEOF_LONG), // 11
                new ScalarAttribute("newPartLength", Constants.Value.SIZEOF_INT), // 12
                new ArrayAttribute("newPartString", Constants.Value.SIZEOF_BYTE), // 13
                new ScalarAttribute("parentLength", Constants.Value.SIZEOF_INT), // 14
                new ArrayAttribute("parentString", Constants.Value.SIZEOF_BYTE), // 15
            })
        { }
    }
}

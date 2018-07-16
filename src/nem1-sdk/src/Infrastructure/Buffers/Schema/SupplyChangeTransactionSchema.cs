using System.Collections.Generic;
using io.nem1.sdk.Infrastructure.Buffers.SchemaHelpers;

namespace io.nem1.sdk.Infrastructure.Buffers.Schema
{
    internal class SupplyChangeTransactionSchema : SchemaHelpers.Schema
    {
        internal SupplyChangeTransactionSchema() : base(
            new List<SchemaAttribute> {
                new ScalarAttribute("transactionType", Constants.Value.SIZEOF_INT), // 1
                new ScalarAttribute("version", Constants.Value.SIZEOF_SHORT), // 2
                new ScalarAttribute("network", Constants.Value.SIZEOF_SHORT), // 3
                new ScalarAttribute("timestamp", Constants.Value.SIZEOF_INT), // 4
                new ScalarAttribute("publicKeyLen", Constants.Value.SIZEOF_INT), // 5
                new ArrayAttribute("publicKey", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("fee", Constants.Value.SIZEOF_LONG), // 7
                new ScalarAttribute("deadline", Constants.Value.SIZEOF_INT), // 8
                new ScalarAttribute("lengthMosaicIdStructure", Constants.Value.SIZEOF_INT), // 9
                new ScalarAttribute("lengthNamespaceIdString", Constants.Value.SIZEOF_INT), // 10
                new ArrayAttribute("namespaceIdString", Constants.Value.SIZEOF_BYTE), // 11
                new ScalarAttribute("lengthMosaicNameString", Constants.Value.SIZEOF_INT), // 10
                new ArrayAttribute("mosaicIdString", Constants.Value.SIZEOF_BYTE), // 11
                new ScalarAttribute("supplyType", Constants.Value.SIZEOF_INT), // 10
                new ScalarAttribute("delta", Constants.Value.SIZEOF_LONG), // 10
            })
        { }
    }
}

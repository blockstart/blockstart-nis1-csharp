using System.Collections.Generic;
using io.nem1.sdk.Infrastructure.Buffers.SchemaHelpers;

namespace io.nem1.sdk.Infrastructure.Buffers.Schema
{
    internal class MosaicDefinitionTransactionSchema : SchemaHelpers.Schema
    {
        internal MosaicDefinitionTransactionSchema() : base(
            new List<SchemaAttribute> {
                new ScalarAttribute("transactionType", Constants.Value.SIZEOF_INT), // 1
                new ScalarAttribute("version", Constants.Value.SIZEOF_SHORT), // 2
                new ScalarAttribute("network", Constants.Value.SIZEOF_SHORT), // 3
                new ScalarAttribute("timestamp", Constants.Value.SIZEOF_INT), // 4
                new ScalarAttribute("publicKeyLen", Constants.Value.SIZEOF_INT), // 5
                new ArrayAttribute("publicKey", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("fee", Constants.Value.SIZEOF_LONG), // 7
                new ScalarAttribute("deadline", Constants.Value.SIZEOF_INT), // 8
                new ScalarAttribute("mosaicDefinitionStructureLength", Constants.Value.SIZEOF_INT), // 8
                new ScalarAttribute("lengthCreatorPublicKey", Constants.Value.SIZEOF_INT), // 8
                new ArrayAttribute("creatorPublicKey", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("lengthOfMosaicIdStructure", Constants.Value.SIZEOF_INT), // 8
                new ScalarAttribute("lengthOfNamespaceIdString", Constants.Value.SIZEOF_INT), // 8
                new ArrayAttribute("namespaceIdString", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("lengthOfMosaicNameString", Constants.Value.SIZEOF_INT), // 8
                new ArrayAttribute("mosaicNameString", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("lengthOfDescription", Constants.Value.SIZEOF_INT), // 8
                new ArrayAttribute("descriptionString", Constants.Value.SIZEOF_BYTE), // 6
                new ScalarAttribute("noOfProperties", Constants.Value.SIZEOF_INT), // 8
                new TableArrayAttribute("properties", new List<SchemaAttribute>{
                    new ScalarAttribute("lengthOfPropertyStructure", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("lengthOfPropertyName", Constants.Value.SIZEOF_INT),  
                    new ArrayAttribute("propertyName", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("lengthOfPropertyValue", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("propertyValue", Constants.Value.SIZEOF_BYTE)
                }),
                new TableArrayAttribute("levy", new List<SchemaAttribute>{
                    new ScalarAttribute("lengthOfLevyStructure", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("feeType", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("lengthOfRecipientAddress", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("recipientAddress", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("lengthOfMosaicIdStructure", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("lengthOfMosaicNamespaceId", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("namespaceIdString", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("lengthMosaicNameString", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("mosaicNameString", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("feeQuantity", Constants.Value.SIZEOF_LONG),
                }),
                new ScalarAttribute("lengthFeeSink", Constants.Value.SIZEOF_INT),
                new ArrayAttribute("feeSink", Constants.Value.SIZEOF_BYTE),
                new ScalarAttribute("feeQuantity", Constants.Value.SIZEOF_LONG),
            })
        { }
    }
}

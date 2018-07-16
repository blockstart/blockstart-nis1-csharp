//
// Copyright 2018 NEM
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Collections.Generic;
using io.nem1.sdk.Infrastructure.Buffers.SchemaHelpers;

namespace io.nem1.sdk.Infrastructure.Buffers.Schema
{
    internal class TransferTransactionSchema : SchemaHelpers.Schema
    {
        internal TransferTransactionSchema() : base(
            new List<SchemaAttribute> {
                new ScalarAttribute("transactionType", Constants.Value.SIZEOF_INT), // 1
                new ScalarAttribute("version", Constants.Value.SIZEOF_SHORT), // 2
                new ScalarAttribute("network", Constants.Value.SIZEOF_SHORT), // 3
                new ScalarAttribute("timestamp", Constants.Value.SIZEOF_INT), // 4
                new ScalarAttribute("publicKeyLen", Constants.Value.SIZEOF_INT), // 5
                new ArrayAttribute("publicKey", Constants.Value.SIZEOF_BYTE),
                new ScalarAttribute("fee", Constants.Value.SIZEOF_LONG), // 6
                new ScalarAttribute("deadline", Constants.Value.SIZEOF_INT), // 7
                new ScalarAttribute("recipientLen", Constants.Value.SIZEOF_INT), // 8
                new ArrayAttribute("recipient", Constants.Value.SIZEOF_BYTE),
                new ScalarAttribute("amount", Constants.Value.SIZEOF_LONG), // 9
                new ScalarAttribute("messageFieldLen", Constants.Value.SIZEOF_INT), // 10              
                new TableArrayAttribute("messageStructure", new List<SchemaAttribute>{                  
                    new ScalarAttribute("type", Constants.Value.SIZEOF_INT), // 12
                    new ScalarAttribute("payloadLen", Constants.Value.SIZEOF_INT), // 13
                    new ArrayAttribute("payload", Constants.Value.SIZEOF_BYTE)
                }),
                new ScalarAttribute("noOfMosaics", Constants.Value.SIZEOF_INT), // 11
                new TableArrayAttribute("mosaicStructure", new List<SchemaAttribute>{
                    new ScalarAttribute("mosaicStructureLen", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("mosaicIdStructureLen", Constants.Value.SIZEOF_INT),
                    new ScalarAttribute("namespaceIdLen", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("namespaceString", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("mosaicIdLen", Constants.Value.SIZEOF_INT),
                    new ArrayAttribute("mosaicIdString", Constants.Value.SIZEOF_BYTE),
                    new ScalarAttribute("quantity", Constants.Value.SIZEOF_LONG)
                })
            })
        {}
    }
}


using System.Collections.Generic;
using System.Linq;
using io.nem1.sdk.Model.Mosaics;
using Newtonsoft.Json.Linq;

namespace io.nem1.sdk.Infrastructure.Mapping
{
    internal class MosaicMapping
    {
        internal List<Mosaic> Apply(string mosaics)
        {
            return JObject.Parse(mosaics)["data"].ToList().Select(e => new Mosaic(e["mosaicId"]["namespaceId"].ToString(),
                e["mosaicId"]["name"].ToString(), ulong.Parse(e["quantity"].ToString()))).ToList();
        }
    }
}

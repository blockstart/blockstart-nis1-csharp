using System.Collections.Generic;
using Newtonsoft.Json;

namespace io.nem1.sdk.Model.Wallet
{
    public class WalletAccount
    {
        [JsonProperty("brain")]
        public bool Brain { get; set; }

        [JsonProperty("algo")]
        public string Algo { get; set; }

        [JsonProperty("encrypted")]
        public string Encrypted { get; set; }

        [JsonProperty("iv")]
        public string Iv { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("network")]
        public int Network { get; set; }

        [JsonProperty("child")]
        public string Child { get; set; }
    }

    public class WalletAccounts
    {
        [JsonProperty("account")]
        public List<WalletAccount> Account { get; set; }
    }

    public class WalletObject
    {
        [JsonProperty("privateKey")]
        public string PrivateKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("accounts")]
        public WalletAccounts Accounts { get; set; }
    }
}

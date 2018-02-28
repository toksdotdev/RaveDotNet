using Newtonsoft.Json;

namespace RaveDotNet.Miscellaneous.Card
{
    public class Card
    {
        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }

        [JsonProperty("cardno")]
        public string Cardno { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("expiryyear")]
        public string Expiryyear { get; set; }

        [JsonProperty("expirymonth")]
        public string Expirymonth { get; set; }

        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }
    }
}

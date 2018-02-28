using Newtonsoft.Json;
using RaveDotNet.Services.JSONConverter;

namespace RaveDotNet.CardCharge
{
    public partial class CardChargeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("flwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("settlement_token")]
        public object SettlementToken { get; set; }

        [JsonProperty("cycle")]
        public string Cycle { get; set; }

        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("charged_amount")]
        public long? ChargedAmount { get; set; }

        [JsonProperty("appfee")]
        public long? Appfee { get; set; }

        [JsonProperty("merchantfee")]
        public long? Merchantfee { get; set; }

        [JsonProperty("merchantbearsfee")]
        public long? Merchantbearsfee { get; set; }

        [JsonProperty("chargeResponseCode")]
        public string ChargeResponseCode { get; set; }

        [JsonProperty("chargeResponseMessage")]
        public string ChargeResponseMessage { get; set; }

        [JsonProperty("authModelUsed")]
        public string AuthModelUsed { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("vbvrespmessage")]
        public string Vbvrespmessage { get; set; }

        [JsonProperty("authurl")]
        public string Authurl { get; set; }

        [JsonProperty("vbvrespcode")]
        public string Vbvrespcode { get; set; }

        [JsonProperty("acctvalrespmsg")]
        public object Acctvalrespmsg { get; set; }

        [JsonProperty("acctvalrespcode")]
        public object Acctvalrespcode { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set; }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("is_live")]
        public long? IsLive { get; set; }

        [JsonProperty("createdAt")]
        public System.DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public System.DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public object DeletedAt { get; set; }

        [JsonProperty("customerId")]
        public long? CustomerId { get; set; }

        [JsonProperty("AccountId")]
        public long? AccountId { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("customercandosubsequentnoauth")]
        public bool? Customercandosubsequentnoauth { get; set; }
    }

    public partial class Customer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("customertoken")]
        public object Customertoken { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public System.DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("deletedAt")]
        public object DeletedAt { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }
    }

    public partial class CardChargeResponse
    {
        public static CardChargeResponse FromJson(string json) => JsonConvert.DeserializeObject<CardChargeResponse>(json, Converter.Settings);
    }
}

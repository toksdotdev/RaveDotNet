using RaveDotNet.Services;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaveDotNet.CardCharge;
using RaveDotNet.CardValidation;
using RaveDotNet.Miscellaneous.Card;
using RaveDotNet.Services.Encryption;
using RaveDotNet.Services.JSONConverter;

namespace RaveDotNet
{
    public class Rave
    {
        public static string LIVE_URL = "https://api.ravepay.co";
        public static string DEMO_URL = "http://flw-pms-dev.eu-west-1.elasticbeanstalk.com";

        private readonly Request _client;

        public enum Mode{
            Test,
            Live
        }

        public enum Algorithm {
            Des,
        }

        private string PrivateKey {get; set;}

        private Rave3DesEncryption encryption;

        //private Mode OperationMode { get; set; }

        public Rave(string privateKey, Mode operationMode)
        {
            PrivateKey = privateKey;

            encryption = new Rave3DesEncryption();

            var baseAddress = operationMode.Equals(Mode.Live) ? new Uri(LIVE_URL) : new Uri(DEMO_URL);

            _client = new Request(privateKey, baseAddress);
        }

        /// <summary>
        /// Charge a card
        /// </summary>
        /// <param name="card">Card details of customer</param>
        /// <param name="alg">Algorithm to use for validation</param>
        /// <returns>Details of the outcome of the card charge</returns>
        public async Task<CardChargeResponse> ChargeCardAsync(Card card, Algorithm alg)
        {
            var body = new {
                PBFPubKey = PrivateKey,
                client = encryption.EncryptData(PrivateKey, card.ToJson()),
                alg = alg.ToString()
            };

            var response = await _client.SendRequest(Request.RequestMethod.Post, "flwv3-pug/getpaidx/api/charge", body.ToJson());

            return CardChargeResponse.FromJson(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionReference">The unique reference/ flwRef, unique to the particular transaction being carried out. It is generated for every transaction. This can be retrieved from the card charge response</param>
        /// <param name="otp">A one time Pin sent to the customer’s phone and inputed by the customer for authentication.</param>
        /// <returns>Details of the outcome of the card charge</returns>
        public async  Task<CardValidationResponse> ValidateCardAsync(string transactionReference, int otp)
        {
            var body = new
            {
                PBFPubKey = PrivateKey,
                transaction_reference = transactionReference,
                otp
            };

            var response = await _client.SendRequest(Request.RequestMethod.Post, "/flwv3-pug/getpaidx/api/validatecharge", body.ToJson());

            return CardValidationResponse.FromJson(response);
        }
    }
}

using paycell_web_api_client.Util;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace paycell_web_api_client.Services.GetCardToken
{

    public class HashDataGenerator
    {

        public static string GenerateForRequest(string transactionId, string transactionDateTime)
        {
            string securityData = Constants.APPLICATION_PASSWORD.ToUpper() + Constants.APPLICATION_NAME.ToUpper();

            securityData = Sha256(securityData).ToUpper();

            string hashData = Constants.APPLICATION_NAME.ToUpper() + transactionId.ToUpper() + transactionDateTime.ToUpper() + Constants.SECURE_CODE.ToUpper() + securityData;
            hashData = Sha256(hashData);
            return hashData;
        }

        public static string GenerateForResponse(string transactionId, string responseDateTime, string responseCode, string cardToken)
        {
            string securityData = Constants.APPLICATION_PASSWORD.ToUpper() + Constants.APPLICATION_NAME.ToUpper();
            securityData = Sha256(securityData);
            string hashData = Sha256(Constants.APPLICATION_NAME.ToUpper() + transactionId.ToUpper()
                + responseDateTime.ToUpper() + responseCode.ToUpper()
                + cardToken.ToUpper() + Constants.SECURE_CODE.ToUpper()
                + securityData.ToUpper());
            return hashData;
        }

        /**
         * Encode string with sha256 and represented in Base64
         * @param originalString text to be encoded
         * @return encoded text
         */
        static string Sha256(string originalString)
        {
            try
            {
                SHA256 mySHA256 = SHA256.Create();
                return Convert.ToBase64String(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(originalString)));

            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
using System;
namespace paycell_web_api_client.Util
{
    public static class UniqueIdGenerator
    {

        private static int sequence = 0;

        /**
         * Generates 20 digist ID from sequence
         * @return generated id
         */
        public static string GenerateTransactionId()
        {
            sequence = sequence + 1;
            return sequence.ToString("D20");
        }

        public static string GenerateReferanceNumber()
        {
            return Constants.REFERENCE_NUMBER_PREFIX + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100, 999).ToString("D3");
        }

        public static string KeyGenerator()
        {
            return Guid.NewGuid().ToString().Replace("{", "");
        }
    }
}
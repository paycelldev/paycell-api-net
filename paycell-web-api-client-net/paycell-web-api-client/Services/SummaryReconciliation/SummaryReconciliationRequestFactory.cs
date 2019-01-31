using paycell_web_api_client.ProvisionService;
using paycell_web_api_client.Services.Base;
using paycell_web_api_client.Util;
using System;

namespace paycell_web_api_client.Services.SummaryReconciliation
{
    public class SummaryReconciliationRequestFactory : BaseFactory
    {

        public summaryReconciliationRequest request;

        /**
         * Requet başlatılır.
         *
         * ReferenceNumber: Üye işyeritarfından üretilen tekil değerdir. Provisiona özgüdür. ilk 3 hanesi
         * Paycell tarafından üye işyeri için tanımlanır. 20 haneli numerik bir değerdir.
         *
         * MerchantCode: Paycell taraffından üye iş yeri için tanımlanır.
         */
        public SummaryReconciliationRequestFactory()
        {
            request = new summaryReconciliationRequest()
            {
                requestHeader = CreateRequestHeader(),
                merchantCode = Constants.MERCHANT_CODE
            };
        }

        /**
         *
         * clientIPAddress : Müşteri IP bilgisi
         * 
         * reconciliationDate : İşlemin mutabakatı için PAYCELL sisteminde belirlenen tarih.
         * reconciliationDate YYYYMMDD formatında olacaktır.

         * totalSaleAmount : İlgili tarihte gerçekleşen [Sale] işlemlerinin toplam tutarıdır. İşlem [Reverse] ya da [Refund]
         * edildiği durumda da toplama dahil edilir.
         *
         * totalReverseAmount : İlgili tarihte gerçekleşen [Reverse] işlemlerinin toplam tutarıdır.
         *
         * totalRefundAmount : İlgili tarihte gerçekleşen [Refund] işlemlerinin toplam tutarıdır.
         *
         * totalSaleCount : İlgili tarihte gerçekleşen [Sale] işlemlerinin toplam adedidir.İşlem [Reverse] ya da [Refund]
         * edildiği durumda da toplama dahil edilir.
         *
         * totalReverseCount : İlgili tarihte gerçekleşen [Reverse] işlemlerinin toplam adedidir.
         *
         * totalRefundCount : İlgili tarihte gerçekleşen [Refund] işlemlerinin toplam adedidir.
         *
         * /

        /**
         * Üretilen request döndürülür.
         *
         * @return
         * @throws Exception clientIpAddress/ReconciliationDate/TotalSaleAmount/TotalReverseAmount/
         *         TotalRefundAmount/TotalSaleCount/TotalReverseCount/TotalRefundCount boş ise fırlatılır.
         */
        public summaryReconciliationRequest Build()
        {
            Validate();
            return request;
        }

        /**
         *
         * @throws Exception clientIpAddress/ReconciliationDate/TotalSaleAmount/TotalReverseAmount/
         *         TotalRefundAmount/TotalSaleCount/TotalReverseCount/TotalRefundCount boş ise fırlatılır.
         */
        private void Validate()
        {
            if (request.requestHeader.clientIPAddress == null) {
                    throw new Exception("ClientIpAddress must be set first.");
                }
            if (request.reconciliationDate == null) {
                    throw new Exception("ReconciliationDate must be set first.");
                }
            if (request.totalSaleAmount == null) {
                    throw new Exception("TotalSaleAmount must be set first.");
                }
            if (request.totalReverseAmount == null) {
                    throw new Exception("TotalReverseAmount must be set first.");
                }
            if (request.totalRefundAmount == null) {
                    throw new Exception("TotalRefundAmount must be set first.");
                }
            if (request.totalSaleCountSpecified == false)
            {
                throw new Exception("totalSaleCountSpecified must be set true.");
            }
            if (request.totalRefundCountSpecified == false)
            {
                throw new Exception("totalRefundCountSpecified must be set true.");
            }
            if (request.totalReverseCountSpecified == false)
            {
                throw new Exception("totalReverseCountSpecified must be set true.");
            }
            if (request.totalSaleCount == null) {
                    throw new Exception("TotalSaleCount must be set first.");
                }
            if (request.totalReverseCount == null) {
                    throw new Exception("TotalReverseCount must be set first.");
                }
            if (request.totalRefundCount == null) {
                    throw new Exception("TotalRefundCount must be set first.");
            }
        }

    }
}
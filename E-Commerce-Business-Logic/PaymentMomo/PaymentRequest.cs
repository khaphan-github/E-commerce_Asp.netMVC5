using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.PaymentMomo {
    public class PaymentRequest {
        private const string MOMO_DOMAIN = "https://test-payment.momo.vn";

        private const string PARTNER_CODE = "MOMOJMUD20220907";
        private const string ACCESS_KEY = "4P1sX4jWK4RhExaX";
        private const string SECRET_KEY = "FcnI5hgWY9fkaf5rNRNrR8Ugrq7LaRCw";
        private const string API_ENDPOINT = "https://test-payment.momo.vn/gw_payment/transactionProcessor";

        // HIỂN THỊ TRANG THANH TOÁN THÀNH CÔNG
        private const string RETURN_URL = "https://localhost:44302/Consumer/ConfirmPaymentMomo";

        // DÙNG NGROK https://dashboard.ngrok.com/events/subscriptions
        private const string NOTIFICATION_URL = "https://dashboard.ngrok.com/events/subscriptions";

        private static string orderId = DateTime.Now.Ticks.ToString()+"03";
        private static string requestId = DateTime.Now.Ticks.ToString()+ "03";
        private static string extraData = "";

        public PaymentRequest() {
        }
      
        // TẠO REQUEST
        public static JObject postJsonMessage(string amount, string orderInfo) {
            // make request data
            string requestData = "partnerCode=" +
                PARTNER_CODE + "&accessKey=" +
                ACCESS_KEY + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderId + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                RETURN_URL + "&notifyUrl=" +
                NOTIFICATION_URL + "&extraData=" +
                extraData;


            // make signature
            MomoSecurity hashSignature = new MomoSecurity();

            string signature = hashSignature.signSHA256(requestData, SECRET_KEY);

            // Makke json request
            JObject message = new JObject {
                { "partnerCode", PARTNER_CODE },
                { "accessKey", ACCESS_KEY },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "returnUrl", RETURN_URL },
                { "notifyUrl", NOTIFICATION_URL },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };

            return message;
        }

        public static string sendPaymentRequest(string amount, string orderInfo) {

            string postJsonString = postJsonMessage(amount, orderInfo).ToString();

            try {
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(API_ENDPOINT);

                var postData = postJsonString;

                var data = Encoding.UTF8.GetBytes(postData);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/json";

                httpWReq.ContentLength = data.Length;
                httpWReq.ReadWriteTimeout = 30000;
                httpWReq.Timeout = 15000;
                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

                string jsonresponse = "";

                using (var reader = new StreamReader(response.GetResponseStream())) {

                    string temp = null;
                    while ((temp = reader.ReadLine()) != null) {
                        jsonresponse += temp;
                    }
                }


                //todo parse it
                return jsonresponse;
                //return new MomoResponse(mtid, jsonresponse);

            } catch (WebException e) {
                return e.Message;
            }
        }
    }
}


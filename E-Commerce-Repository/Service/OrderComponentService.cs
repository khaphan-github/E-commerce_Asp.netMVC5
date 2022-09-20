using E_Commerce_Repository.Models;
using System.Collections.Generic;

namespace E_Commerce_Repository.Service {
    interface OrderComponentService {
        // QUẢN LÝ TRẠNG THÁI GIAO HÀNG

        DeliverState GetDeliveryState(int id);
        List<DeliverState> GetDeliverStates();
        void CreateDeliveryState(DeliverState deliveryState);

        void UpdateDeliveryState(DeliverState deliveryState);

        void DeteteDeliveryState(int Id);

        // QUẢN LÝ SHIPPING METHOD
        ShippingMethod GetShippingMethod(int id);

        List<ShippingMethod> GetShippingMethods();

        void CreateShippingMethod(ShippingMethod shippingMethod);
        void UpdateShippingMethod(ShippingMethod shippingMethod);

        void DeleteShippingMethod(int id);
        // QUẢN LÝ PHƯƠNG THỨC THANH TOÁN

        PaymentMethod GetPaymentMethod(int Id);
        List<PaymentMethod> GetPaymentMethods();

        void CreatPaymentMethod(PaymentMethod paymentMethod);

        void UpdatePaymentMethod(PaymentMethod paymentMethod);

        void DeletePaymentMethod(int Id);
    }
}

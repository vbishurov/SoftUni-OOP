package Shop1lv.Logic;

import Shop1lv.Customer;
import Shop1lv.Interfaces.Expireable;
import Shop1lv.Product;

import java.util.Date;

public class PurchaseManager {
    public static void processPurchase(Customer customer, Product product) {
        if (product.getQuantity() < 1) {
            throw new IllegalArgumentException("Not enough quantity");
        }

        if (product instanceof Expireable && ((Expireable) product).getExpirationDate().compareTo(new Date()) < 0) {
            throw new IllegalArgumentException("Product has expired");
        }

        if (customer.getBalance() < product.getPrice()) {
            throw new IllegalArgumentException("You do not have enough money to buy this product!");
        }

        switch (product.getAgeRestriction()) {
            case Teenager:
                if (customer.getAge() < 13) {
                    throw new IllegalArgumentException("You are too young to buy this product!");
                }
                break;
            case Adult:
                if (customer.getAge() < 18) {
                    throw new IllegalArgumentException("You are too young to buy this product!");
                }
                break;
        }

        customer.setBalance(customer.getBalance() - product.getPrice());
        product.setQuantity(product.getQuantity() - 1);
    }
}

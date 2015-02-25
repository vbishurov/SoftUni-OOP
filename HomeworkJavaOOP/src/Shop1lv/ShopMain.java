package Shop1lv;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Interfaces.Expireable;
import Shop1lv.Logic.PurchaseManager;
import Shop1lv.Products.ElectronicProducts.Appliance;
import Shop1lv.Products.ElectronicProducts.Computer;
import Shop1lv.Products.FoodProduct;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class ShopMain {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.Adult, new Date(2014, 2, 20));
        Customer pecata = new Customer("Pecata", 17, 30.00);
        Customer gopeto = new Customer("Gopeto", 18, 0.44);
        Computer computer = new Computer("Computer", 4300, AgeRestriction.None, 400);
        Appliance oven = new Appliance("Oven", 250, AgeRestriction.Adult, 1500);
        FoodProduct apple = new FoodProduct("Apple", 1.99, 300, AgeRestriction.None, new Date(2014, 2, 20));
        FoodProduct orange = new FoodProduct("Orange", 0.90, 1656, AgeRestriction.None, new Date(2014, 2, 20));

        List<Product> products = Arrays.asList(cigars, computer, oven, apple, orange);

        try {
            PurchaseManager.processPurchase(pecata, cigars);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        try {
            PurchaseManager.processPurchase(gopeto, cigars);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        products.
                stream().
                filter(i -> i instanceof Expireable).
                sorted((i1, i2) -> ((Expireable) i1).getExpirationDate().compareTo(((Expireable) i2).getExpirationDate())).
                limit(1).
                forEach(i -> System.out.println(i.getName()));

        products.
                stream().
                filter(i -> i.getAgeRestriction() == AgeRestriction.Adult).
                sorted((i1, i2) -> i1.getPrice() > i2.getPrice() ? 1 : -1).
                forEach(i -> System.out.println(i.getPrice()));
    }
}

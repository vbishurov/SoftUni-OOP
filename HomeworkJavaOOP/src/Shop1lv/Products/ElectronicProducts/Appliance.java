package Shop1lv.Products.ElectronicProducts;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Products.ElectronicsProduct;

public class Appliance extends ElectronicsProduct {
    public Appliance(String name, double price, AgeRestriction ageRestriction, int quantity) {
        super(name, price, ageRestriction, quantity, 6);
        this.ModifyPriceOnQuantity();
    }

    private void ModifyPriceOnQuantity() {
        if (this.getQuantity() < 50) {
            this.setPrice(1.05 * this.getPrice());
        }
    }
}

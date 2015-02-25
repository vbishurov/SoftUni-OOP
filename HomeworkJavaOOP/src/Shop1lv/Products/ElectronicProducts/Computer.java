package Shop1lv.Products.ElectronicProducts;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Products.ElectronicsProduct;

public class Computer extends ElectronicsProduct{
    public Computer(String name, double price, AgeRestriction ageRestriction, int quantity) {
        super(name, price, ageRestriction, quantity, 24);
        this.ModifyPriceOnQuantity();
    }

    private void ModifyPriceOnQuantity() {
        if (this.getQuantity() > 1000) {
            this.setPrice(0.95 * this.getPrice());
        }
    }
}

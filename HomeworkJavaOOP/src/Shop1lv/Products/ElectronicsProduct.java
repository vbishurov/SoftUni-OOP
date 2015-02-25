package Shop1lv.Products;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Product;

public class ElectronicsProduct extends Product {
    private int guaranteePeriod;

    public ElectronicsProduct(String name, double price, AgeRestriction ageRestriction, int quantity, int guaranteePeriod) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriod(guaranteePeriod);
    }

    public int getGuaranteePeriod() {
        return guaranteePeriod;
    }

    private void setGuaranteePeriod(int guaranteePeriod) {
        this.guaranteePeriod = guaranteePeriod;
    }
}

package Shop1lv.Products;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Interfaces.Expireable;
import Shop1lv.Product;

import java.util.Date;

public class FoodProduct extends Product implements Expireable {
    private Date expirationDate;

    public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction, Date expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    @Override
    public Date getExpirationDate() {
        if (new Date().compareTo(this.expirationDate) < 15) {
            this.setPrice(0.7 * this.getPrice());
        }

        return this.expirationDate;
    }

    private void setExpirationDate(Date expirationDate) {
        this.expirationDate = expirationDate;
    }
}

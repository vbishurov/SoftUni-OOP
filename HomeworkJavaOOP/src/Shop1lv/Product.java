package Shop1lv;

import Shop1lv.Enums.AgeRestriction;
import Shop1lv.Interfaces.Buyable;

public abstract class Product implements Buyable {
    private String name;
    private double price;
    private int quantity;
    private AgeRestriction ageRestriction;

    public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
        this.setName(name);
        this.setPrice(price);
        this.setAgeRestriction(ageRestriction);
        this.setQuantity(quantity);
    }

    @Override
    public double getPrice() {
        return this.price;
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        this.name = name;
    }

    protected void setPrice(double price) {
        this.price = price;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestriction;
    }

    private void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestriction = ageRestriction;
    }
}

package Geometry.Geometry2D;

import Geometry.Vertex2D;

public class Rectangle extends PlaneShape {
    private double width, height;

    public Rectangle(Vertex2D topLeft, double width, double height) {
        super(topLeft);
        this.setWidth(width);
        this.setHeight(height);
    }

    public double getWidth() {
        return width;
    }

    protected void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    protected void setHeight(double height) {
        this.height = height;
    }

    @Override

    public double getArea() {
        return this.getWidth() * this.getHeight();
    }

    @Override
    public double getPerimeter() {
        return 2 * (this.getWidth() + this.getHeight());
    }

    @Override
    public String toString() {
        return String.format("Rectangle(%s, %.2f, %.2f)", this.getVertices().get(0), this.getWidth(), this.getHeight());
    }
}

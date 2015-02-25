package Geometry.Geometry2D;

import Geometry.Vertex2D;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(Vertex2D center, double radius) {
        super(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return radius;
    }

    protected void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public double getArea() {
        return Math.PI * Math.PI * this.getRadius();
    }

    @Override
    public double getPerimeter() {
        return 2 * Math.PI * this.getRadius();
    }

    @Override
    public String toString() {
        return String.format("Circle(%s, %.2f)", this.getVertices().get(0), this.getRadius());
    }
}

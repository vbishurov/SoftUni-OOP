package Geometry.Geometry3D;

import Geometry.Vertex3D;

public class Sphere extends SpaceShape {
    protected double radius;

    public Sphere(Vertex3D v1, double radius) {
        super(v1);
        this.setRadius(radius);
    }

    @Override
    public double getArea() {
        return 4 * Math.PI * this.getRadius() * this.getRadius();
    }

    @Override
    public double getVolume() {
        return Math.PI * Math.PI * Math.PI * this.getRadius() * 4 / 3;
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public String toString() {
        return String.format("Sphere(%s, %.2f)", this.getVertices().get(0), this.getRadius());
    }
}

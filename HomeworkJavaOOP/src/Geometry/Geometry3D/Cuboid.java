package Geometry.Geometry3D;

import Geometry.Vertex3D;

public class Cuboid extends SpaceShape {
    protected double width;
    protected double height;
    protected double depth;

    public Cuboid(Vertex3D v1, double width, double height, double depth) {
        super(v1);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    @Override
    public double getArea() {
        return 2 * (this.getWidth() * this.getHeight() + this.getWidth() * this.getDepth() + this.getDepth() * this.getHeight());
    }

    @Override
    public double getVolume() {
        return this.getDepth() * this.getWidth() * this.getHeight();
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getDepth() {
        return depth;
    }

    public void setDepth(double depth) {
        this.depth = depth;
    }

    @Override
    public String toString() {
        return String.format("Cuboid(%s, %.2f, %.2f, %.2f)",
                this.getVertices().get(0), this.getWidth(), this.getHeight(), this.getDepth());
    }
}

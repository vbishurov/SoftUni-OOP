package Geometry.Geometry3D;

import Geometry.Vertex3D;

public class SquarePyramid extends SpaceShape {
    private double baseWidth, pyramidHeight;

    public SquarePyramid(Vertex3D baseCenter, double baseWidth, double pyramidHeight) {
        super(baseCenter);
        this.setBaseWidth(baseWidth);
        this.setPyramidHeight(pyramidHeight);
    }

    public double getBaseWidth() {
        return baseWidth;
    }

    public void setBaseWidth(double baseWidth) {
        this.baseWidth = baseWidth;
    }

    public double getPyramidHeight() {
        return pyramidHeight;
    }

    public void setPyramidHeight(double pyramidHeight) {
        this.pyramidHeight = pyramidHeight;
    }

    @Override
    public double getArea() {
        double baseArea = this.getBaseWidth() * this.getBaseWidth();
        double sideArea = baseArea / 2 * this.getPyramidHeight();
        return baseArea + (4 * sideArea);
    }

    @Override
    public double getVolume() {
        return (this.getBaseWidth() * this.getBaseWidth()) * this.getPyramidHeight() / 3;
    }

    @Override
    public String toString() {
        return String.format("Square Pyramid(%s, %.2f, %.2f)", this.getVertices().get(0), this.getBaseWidth(), this.getPyramidHeight());
    }
}

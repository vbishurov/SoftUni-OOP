package Geometry.Geometry2D;

import Geometry.Vertex2D;

public class Triangle extends PlaneShape {

    public Triangle(Vertex2D v1, Vertex2D v2, Vertex2D v3) {
        super(v1, v2, v3);
    }

    @Override
    public double getArea() {
        double halfPerimeter = this.getPerimeter() / 2;
        double sideA = this.getVertices().get(0).measureDistance(this.getVertices().get(1));
        double sideB = this.getVertices().get(0).measureDistance(this.getVertices().get(2));
        double sideC = this.getVertices().get(1).measureDistance(this.getVertices().get(2));

        return Math.sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
    }

    @Override
    public double getPerimeter() {
        double sideA = this.getVertices().get(0).measureDistance(this.getVertices().get(1));
        double sideB = this.getVertices().get(0).measureDistance(this.getVertices().get(2));
        double sideC = this.getVertices().get(1).measureDistance(this.getVertices().get(2));

        return sideA + sideB + sideC;
    }

    @Override
    public String toString() {
        return String.format("Triangle(%s, %s, %s)", this.getVertices().get(0), this.getVertices().get(1), this.getVertices().get(2));
    }
}

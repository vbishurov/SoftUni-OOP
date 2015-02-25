package Geometry;

public class Vertex2D {
    private double x;
    private double y;

    public Vertex2D(double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return x;
    }

    protected void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    protected void setY(double y) {
        this.y = y;
    }

    public double measureDistance(Vertex2D v) {
        return Math.sqrt(((this.getX() - v.getX()) * (this.getX() - v.getX())) +
                ((this.getY() - v.getY()) * (this.getY() - v.getY())));
    }

    @Override
    public String toString() {
        return String.format("{%.2f, %.2f}", this.getX(), this.getY());
    }
}

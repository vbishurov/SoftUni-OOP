package Geometry;

public class Vertex3D extends Vertex2D {
    private double z;

    public Vertex3D(double x, double y, double z) {
        super(x, y);
        this.setZ(z);
    }

    public double getZ() {
        return z;
    }

    public void setZ(double z) {
        this.z = z;
    }

    @Override
    public String toString() {
        return String.format("{%s, %s, %s}", this.getX(), this.getY(), this.getZ());
    }
}

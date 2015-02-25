package Geometry.Geometry2D;

import Geometry.Interfaces.AreaMeasurable;
import Geometry.Interfaces.PerimeterMeasurable;
import Geometry.Shape;
import Geometry.Vertex2D;
import java.util.Arrays;
import java.util.List;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable {
    private List<Vertex2D> vertices;

    public PlaneShape(Vertex2D... vertices) {
        this.setVertices(Arrays.asList(vertices));
    }

    public List<Vertex2D> getVertices() {
        return vertices;
    }

    protected void setVertices(List<Vertex2D> vertices) {
        this.vertices = vertices;
    }
}

package Geometry.Geometry3D;

import Geometry.Interfaces.AreaMeasurable;
import Geometry.Interfaces.PerimeterMeasurable;
import Geometry.Interfaces.VolumeMeasurable;
import Geometry.Shape;
import Geometry.Vertex3D;
import java.util.Arrays;
import java.util.List;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
    private List<Vertex3D> vertices;

    public SpaceShape(Vertex3D... vertices) {
        this.vertices = Arrays.asList(vertices);
    }

    public List<Vertex3D> getVertices() {
        return vertices;
    }

    public void setVertices(List<Vertex3D> vertices) {
        this.vertices = vertices;
    }
}

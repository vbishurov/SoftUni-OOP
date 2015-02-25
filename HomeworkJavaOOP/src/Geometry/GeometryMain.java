package Geometry;

import Geometry.Geometry2D.Circle;
import Geometry.Geometry2D.PlaneShape;
import Geometry.Geometry2D.Rectangle;
import Geometry.Geometry2D.Triangle;
import Geometry.Geometry3D.Cuboid;
import Geometry.Geometry3D.Sphere;
import Geometry.Geometry3D.SquarePyramid;
import Geometry.Interfaces.VolumeMeasurable;
import com.sun.deploy.panel.ITreeNode;

import javax.swing.text.StyledEditorKit;
import java.util.Arrays;

public class GeometryMain {
    public static void main(String[] args) {
        Triangle triangle = new Triangle(new Vertex2D(2, 3), new Vertex2D(5, 6), new Vertex2D(2, 10));

        Rectangle rectangle = new Rectangle(new Vertex2D(7, 7), 10, 15);

        Circle circle = new Circle(new Vertex2D(0, 0), 5);

        Cuboid cuboid = new Cuboid(new Vertex3D(0, 0, 0), 30, 10, 15);

        SquarePyramid squarePyramid = new SquarePyramid(new Vertex3D(0, 0, 0), 10, 8);

        Sphere sphere = new Sphere(new Vertex3D(0, 0, 0), 10);

        Shape[] shapes = {triangle, rectangle, circle, cuboid, squarePyramid, sphere};

        for (Shape item : shapes) {
            System.out.println(item);
        }

        System.out.println();

        Arrays.asList(shapes).
                stream().
                filter((i -> i instanceof VolumeMeasurable)).
                filter(i -> ((VolumeMeasurable) i).getVolume() > 40).
                forEach(i -> System.out.println("Volume: " + ((VolumeMeasurable) i).getVolume()));

        System.out.println();

        Arrays.asList(shapes).
                stream().
                filter(i -> i instanceof PlaneShape).
                sorted((i1, i2) -> ((PlaneShape) i1).getPerimeter() > ((PlaneShape) i2).getPerimeter() ? 1 : -1).
                forEach(i -> System.out.println(((PlaneShape) i).getPerimeter()));
    }
}

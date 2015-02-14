namespace EnvironmentSystem.Interfaces
{
    using Models.Data.Structures;

    public interface IRenderable
    {
        Rectangle Bounds { get; }

        char[,] ImageProfile { get; }
    }
}

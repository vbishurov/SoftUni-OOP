namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;
    using Models.Objects;

    public interface IObjectProducer
    {
        IEnumerable<EnvironmentObject> ProduceObjects();
    }
}

namespace Order.Application.CommonBehavior.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name)
        : base($"Entity: \"{name}\" not found") { }
    public NotFoundException(string name, object key)
        : base($"Entity: \"{name}\" with key: {key} not found") { }
}

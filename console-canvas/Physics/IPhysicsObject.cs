namespace ConsoleCanvas
{
    public interface IPhysicsObject
    {
        Vector Velocity { get; set; }
        Vector Position { get; set; }
    }
}

namespace ConsoleCanvas
{
    internal class Gravity : IPhysicsRule
    {
        public void Apply(IPhysicsObject physicsObject)
        {
            physicsObject.Velocity = physicsObject.Velocity + new Vector(0, .08f);
        }
    }
}

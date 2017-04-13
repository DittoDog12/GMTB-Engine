using Microsoft.Xna.Framework;

namespace GMTB.AI
{
    public interface IAI
    {
        Vector2 PlayerPos { set; }
        bool PlayerVisible { set; }
        string State { get; }
        void Update(GameTime gameTime);

        bool CollisionChecker();

        void Idle();
    }
}

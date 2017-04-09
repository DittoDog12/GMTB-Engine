using Microsoft.Xna.Framework;

namespace GMTB
{
    public interface hasProximity
    {
        Rectangle ProximityBox { get; }
        void inProximity(object source, ProximityEvent args);
    }
}

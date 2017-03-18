using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMTB
{
    public interface IInput
    {
        void SubscribeMove(EventHandler<InputEvent> handler);
        void Unsubscribe(EventHandler<InputEvent> handler);
        void SubscribeExit(EventHandler<InputEvent> handler);
        void SubscribeSpace(EventHandler<InputEvent> handler);
        void UnSubscribeSpace(EventHandler<InputEvent> handler);
        void Update();
    }
}

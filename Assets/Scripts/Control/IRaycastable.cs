using System;
namespace MMORPG.Control
{
    public interface IRaycastable
    {
        public CursorType GetCursorType();
        public bool HandleRaycast();
    }
}
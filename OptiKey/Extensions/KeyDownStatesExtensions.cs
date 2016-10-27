using OptiKey.Enums;

namespace OptiKey.Extensions
{
    public static class KeyDownStatesExtensions
    {
        public static bool IsDownOrLockedDown(this KeyDownStates value)
        {
            return value == KeyDownStates.Down || value == KeyDownStates.LockedDown;
        }
    }
}

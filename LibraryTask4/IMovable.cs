using ClassLibrary;

namespace Laba_DLL
{
    public interface IMovable
    {
        Vector3 position { get; set; }
        Vector3 velocity { get; set; }
        void Move();
    }
}

using System.IO;

namespace Debugging
{
    public static class ExceptionThrower
    {
        public static void Throw()
        {
            throw new FileNotFoundException("File not found exception from Debugging.dll");
        }
    }
}
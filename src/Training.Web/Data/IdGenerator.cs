using System;
using System.Threading;

namespace Training.Web.Data
{
    public static class IdGenerator
    {
        static int _currentId;

        public static int NextId()
        {
            return Interlocked.Increment(ref _currentId);
        }
    }
}
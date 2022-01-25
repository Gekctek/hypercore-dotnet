using CLibrary;
using System;

namespace Automerge
{

    public class AutomergeBackend : IDisposable
    {
        private IntPtr _backend;
        private AutomergeBackend(IntPtr backend)
        {
            _backend = backend;
        }

        public int ApplyLocalChange(string request)
        {
            return CLibrary.Automerge.apply_local_change(this._backend, request);
        }

        public void Dispose()
        {
            // TODO
        }

        public static AutomergeBackend Init()
        {
            IntPtr backend = CLibrary.Automerge.automerge_init();
            return new AutomergeBackend(backend);
        }
    }
}
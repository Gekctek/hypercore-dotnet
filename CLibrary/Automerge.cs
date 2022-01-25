using System;
using System.Runtime.InteropServices;

namespace CLibrary
{
    public static class Automerge
    {
        [DllImport("automerge/libautomerge.so")]
        public unsafe static extern IntPtr automerge_init();
        [DllImport("automerge/libautomerge.so", CharSet = CharSet.Ansi, EntryPoint = "automerge_apply_local_change" )]
        [return : MarshalAs( UnmanagedType.LPStr)] // Convert pointer to strng
        public unsafe static extern string apply_local_change(IntPtr backend, [MarshalAs(UnmanagedType.LPStr)] string request);
    }
}
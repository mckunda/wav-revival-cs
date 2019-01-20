using System;
using System.Runtime.InteropServices;

namespace ConWavRevivalLibTest
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DoubleArray
    {
        public UInt64 size;

        public UInt64 capacity;
        
        public IntPtr data;
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Dinit(UInt64 capacity);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Ddel(IntPtr self);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Dshrink_to_fit(IntPtr self);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Dresize(IntPtr self, UInt64 new_size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Dpush_back(IntPtr self, Double val);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Dpush_some(IntPtr self, UInt64 count, Double val);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Dbegin(IntPtr self);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Dend(IntPtr self);
        
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Dprint(IntPtr self);

    
    [StructLayout(LayoutKind.Sequential)]
    public struct DoubleArrayApi
    {
        [MarshalAs(UnmanagedType.Bool)]
        public Boolean _is_initialized;
        
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dinit init;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Ddel del;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dshrink_to_fit shrink_to_fit;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dresize resize;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dpush_back push_back;
    
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dpush_some push_some;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dbegin begin;
    
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dend end;
        
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Dprint print;

    }
}
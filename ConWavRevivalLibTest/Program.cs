using System;
using System.Runtime.InteropServices;

namespace ConWavRevivalLibTest
{
    class Program
    {
        [DllImport("/home/mckunda/CLionProjects/wav-revival-lib/cmake-build-release/lib/libWavRevival.so")]
        public static extern IntPtr double_array_api();
        
        static void Main(string[] args)
        {
            var api = Marshal.PtrToStructure<DoubleArrayApi>(double_array_api());

            var doubleArrayPtr = api.init(0);

            api.push_back(doubleArrayPtr, 1.5);
            api.push_back(doubleArrayPtr, 2.7);
            api.push_back(doubleArrayPtr, 3.83);
            api.print(doubleArrayPtr);

            var doubleArrayData = Marshal.PtrToStructure<DoubleArray>(doubleArrayPtr);

            double[] arr = new double[doubleArrayData.size];

            Marshal.Copy(doubleArrayData.data, arr, 0, (int)doubleArrayData.size);

            api.del(doubleArrayPtr);
        }
    }
}
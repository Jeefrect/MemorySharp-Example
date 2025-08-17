using System.Diagnostics;
using Binarysharp.MemoryManagement;

namespace T3_Trainer;

class MemoryHandler(Process targetProcess)
{
    private readonly MemorySharp _memorySharp = new MemorySharp(targetProcess);
    public IntPtr ResolvePointerChain(IntPtr baseAddress, int[] offsets)
    {
        IntPtr currentAddress = baseAddress;

        for (int i = 0; i < offsets.Length; i++)
        {
            currentAddress = _memorySharp.Read<int>(currentAddress, 1, false)[0];
            
            if (i < offsets.Length)
                currentAddress += offsets[i];
        }

        return currentAddress;
    }
    public int ReadInt32(IntPtr address) => _memorySharp.Read<int>(address, 1, false)[0];
    public void WriteInt32(IntPtr address, int value) => _memorySharp.Write(address, new int[] { value }, false);
}
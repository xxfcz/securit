using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace gp01
{
    class Program
    {
        static void Main(string[] args)
        {
/*            ComputerGroupPolicyObject.SetPolicySetting(@"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate!WUServer", "http://10.160.5.20:8531", RegistryValueKind.String);
            ComputerGroupPolicyObject.SetPolicySetting(@"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate!WUStatusServer", "http://10.160.5.20:8531", RegistryValueKind.String);
            ComputerGroupPolicyObject.SetPolicySetting(@"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU!UseWUServer", "1", RegistryValueKind.DWord);
*/
            ComputerGroupPolicyObject.SetPolicySetting(@"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoDriveTypeAutoRun", "255", RegistryValueKind.DWord);
           
            // start gpedit.msc for the changes to take effects
            Process p = Process.Start("gpedit.msc");
            if(p.WaitForInputIdle())
            {
                try
                {
                    p.CloseMainWindow();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    p.Kill();
                }
            }
        }
    }
}

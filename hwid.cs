using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace znix_panel_v2_loader {
    class hwid {
        //you shouldn't use guids, whatever.

        public static string get_machine_guid( ) {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using ( RegistryKey localMachineX64View = RegistryKey.OpenBaseKey( RegistryHive.LocalMachine, RegistryView.Registry64 ) ) {
                using ( RegistryKey rk = localMachineX64View.OpenSubKey( location ) ) {
                    if ( rk == null )
                        throw new KeyNotFoundException( string.Format( "Key Not Found: {0}", location ) );

                    object machineGuid = rk.GetValue( name );
                    if ( machineGuid == null )
                        throw new IndexOutOfRangeException( string.Format( "Index Not Found: {0}", name ) );

                    return machineGuid.ToString( );
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace znix_panel_v2_loader {
    class utils {
        /* Modules used in wait_for_modules() */
        public static string[] modules = { "client.dll", "engine.dll" };

        /* Get panel url (https://panel.your.domain/) */
        public static string get_panel_url( ) {
            return "http://website/panel/";
        }

        public static string get_api_link( ) {
            return "api.php";
        }

        public static string get_api_key( ) {
            return "yes";
        }

        /* Censors input */
        public static string read_pass( ) {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey( true );
            while ( info.Key != ConsoleKey.Enter ) {
                if ( info.Key != ConsoleKey.Backspace ) {
                    Console.Write( "*" );
                    password += info.KeyChar;
                }
                else if ( info.Key == ConsoleKey.Backspace ) {
                    if ( !string.IsNullOrEmpty( password ) ) {
                        password = password.Substring( 0, password.Length - 1 );
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition( pos - 1, Console.CursorTop );
                        Console.Write( " " );
                        Console.SetCursorPosition( pos - 1, Console.CursorTop );
                    }
                }

                info = Console.ReadKey( true );
            }

            Console.WriteLine( );
            return password;
        }

        /* Waits for selected modules to be loaded in csgo */
        public static void wait_for_modules( ) {
            Process[] pname = Process.GetProcessesByName( "csgo" );
            if ( pname.Length == 0 )
                Process.Start( @"steam://rungameid/730" );

            var loadedModules = new List<string>( modules.Length );

            Process[] process;

            while ( loadedModules.Count < modules.Length ) {
                process = Process.GetProcessesByName( "csgo" );

                if ( process.Length < 1 ) continue;

                foreach ( ProcessModule module in process[0].Modules ) {
                    if ( modules.Contains( module.ModuleName ) && !loadedModules.Contains( module.ModuleName ) ) {
                        loadedModules.Add( module.ModuleName );

                        switch ( module.ModuleName ) {
                            case "client.dll":
                                break;
                            case "engine.dll":
                                break;
                        }
                    }
                }

                Thread.Sleep( 250 );
            }
        }
    }
}
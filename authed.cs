using System;
using System.Threading;

namespace znix_panel_v2_loader {
    internal class authed {
        public static void Authed( ) {
            Console.Clear( );
            Console.WriteLine( "cheat" );
            Console.WriteLine( $"welcome back, {Program.login_username}!" );
            Console.WriteLine( "1. inject" );
            Console.WriteLine( "2. exit" );
            Console.WriteLine( "option : " );
            var a = Console.ReadLine( );
            var flag = a == "1";
            if ( flag ) {
                Console.Clear( );
                Console.WriteLine( "cheat" );
                Console.WriteLine( "loading..." );
                @catch.CatchInjectMM( );
                Console.ReadKey( );
            }
            else {
                bool flag2 = a == "2";
                if ( flag2 ) {
                    Console.WriteLine( "closing in 5 seconds." );
                    Thread.Sleep( 5000 );
                    Environment.Exit( 0 );
                }
                else {
                    Console.WriteLine( "please choose either 1 or 2" );
                    Thread.Sleep( 1000 );
                    @catch.CatchAuthed( );
                }
            }
        }
    }
}
// what you should do before using this for your ::: SELF CODED P2C SERVICE :::
// encrypt requests.
// encrypt strings.
// get a better hwid system

// probably has a few small problems but if you cant fix them you shouldn't be running a hack

using System;
using System.Linq;

namespace znix_panel_v2_loader {
    public class Program {
        public const string dll_link = "http://website/panel/dll.dll";

        public static string login_username { get; set; }
        public static string login_password { get; set; }

        private static readonly Random random = new Random( );

        public static string random_string( int length ) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string( Enumerable.Repeat( chars, length ).Select( s => s[random.Next( s.Length )] ).ToArray( ) );
        }

        public static void entry( ) {
            Console.Title = random_string( 42 );

            @catch.CatchLogin( );
        }

        public static void Main( ) => entry( );
    }
}

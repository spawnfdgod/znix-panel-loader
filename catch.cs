using System;

namespace znix_panel_v2_loader {
    class @catch {
        public static void CatchLogin( ) {
            try {
                login.Login( );
            }
            catch ( Exception e ) {
                if ( e.InnerException != null ) {
                    string err = e.ToString( );
                    Console.WriteLine( "an error has occured, contact staff (" + err + ")" );
                }
            }
        }

        public static void CatchAuthed( ) {
            try {
                authed.Authed( );
            }
            catch ( Exception e ) {
                if ( e.InnerException != null ) {
                    string err = e.ToString( );
                    Console.WriteLine( "an error has occured, contact staff (" + err + ")" );
                }
            }
        }

        public static void CatchInjectMM( ) {
            try {
                inject.inject_live( );
            }
            catch ( Exception e ) {
                if ( e.InnerException != null ) {
                    string err = e.ToString( );
                    Console.WriteLine( "an error has occured, contact staff (" + err + ")" );
                }
            }
        }
    }
}
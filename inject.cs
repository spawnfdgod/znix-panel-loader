using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using znix_panel_v2_loader.Injection;

namespace znix_panel_v2_loader {
    class inject {
        public static async void inject_live( ) {
            Console.Clear( );
            utils.wait_for_modules( );
            const string name = "csgo";
            var target = Process.GetProcessesByName( name ).FirstOrDefault( );
            if ( target == null ) {
                Console.WriteLine( "can not attach to csgo process, try again" );
                return;
            }

            var injector = new ManualMapInjector( target ) { AsyncInjection = true };
            Console.WriteLine( "" );
            Console.WriteLine( "loading" );
            var wb = new WebClient( );
            byte[] rawData = await wb.DownloadDataTaskAsync( "http://website/panel/dll.dll" );
            _ = injector.Inject( rawData ).ToInt64( ); // "_" is a discard, you don't need it here, but I think it's better this way.
            Console.WriteLine( "injected" );
            Thread.Sleep( 10000 );
            Environment.Exit( 0 );
        }
    }
}
using System;
using System.Globalization;
using System.Threading;
using Newtonsoft.Json;

namespace znix_panel_v2_loader {
    internal class login {
        public static string sub;

        private static bool sub_active( ) {
            if ( sub == null )
                return false;
            var value = DateTime.Compare( DateTime.Parse( sub, CultureInfo.InvariantCulture ), DateTime.Now );
            return value > 0;
        }

        public static void Login( ) {
            Console.WriteLine( "GO-GO Cheat" );
            Console.WriteLine( "loader made by website <3" );
            Console.WriteLine( "Enter username:" );
            Program.login_username = Console.ReadLine( );
            Console.WriteLine( "Enter password:" );
            Program.login_password = utils.read_pass( );
            var resp = requests.get_text( utils.get_panel_url( ) + utils.get_api_link( ) + "?user=" + Program.login_username + "&pass=" + base64.encode( Program.login_password ) + "&hwid=" + base64.encode( hwid.get_machine_guid( ) ) + "&key=" + utils.get_api_key( ) );
            var settings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd"
            };
            dynamic resp_json = JsonConvert.DeserializeObject( resp, settings );
            if ( resp_json == null ) return;
            var status = resp_json.status;
            if ( status == "failed" ) {
                string err_type = resp_json.error;
                if ( err_type == "Invalid username" || err_type == "Invalid password" ) {
                    Console.WriteLine( "invalid credentials" ); // invalid credentials
                    Thread.Sleep( 1000 );
                    Environment.Exit( 0 );
                }
                else {
                    Console.WriteLine( "unknown error, contact staff" );
                    Thread.Sleep( 1000 );
                    Environment.Exit( 0 );
                }
            }
            else if ( status == "success" ) {
                Console.WriteLine( "You are logged in successfully" );
                Thread.Sleep( 1000 );
                string is_banned = resp_json.banned;
                if ( is_banned == "1" ) {
                    Console.WriteLine( "you're banned." );
                    Thread.Sleep( 1500 );
                    Environment.Exit( 0 );
                }
                else {
                    string stored_hwid = resp_json.hwid;
                    sub = resp_json.sub;

                    if ( hwid.get_machine_guid( ) == stored_hwid || stored_hwid == null ) {
                        if ( sub_active( ) ) {
                            Console.WriteLine( "you have an active subscription!" );
                            Thread.Sleep( 1500 );
                            authed.Authed( );
                        }
                        else {
                            Console.WriteLine( "you have no active subscription." );
                            Thread.Sleep( 1500 );
                            Environment.Exit( 0 );
                        }
                    }
                    else {
                        Console.WriteLine( "hwid error" );
                        Thread.Sleep( 1500 );
                        Environment.Exit( 0 );
                    }
                }
            }
            else {
                Console.WriteLine( "login failed." );
                Thread.Sleep( 1500 );
                Environment.Exit( 0 );
            }
        }
    }
}
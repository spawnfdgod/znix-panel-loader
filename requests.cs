using System.Net;

namespace znix_panel_v2_loader {
    class requests {
        public static string get_text( string addr ) {
            string response;
            using ( WebClient client = new WebClient( ) ) {
                IWebProxy wp = WebRequest.DefaultWebProxy;
                client.Proxy = wp;
                response = client.DownloadString( addr );
            }

            return response;
        }
    }
}
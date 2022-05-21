using System;
using System.Text;

namespace znix_panel_v2_loader {
    internal class base64 {
        public static string decode( string coded ) {
            // you should probably check String.IsNullOrEmpty but u don't have to

            var bytes = Convert.FromBase64String( coded );
            var text = Encoding.UTF8.GetString( bytes, 0, bytes.Length );
            return text;
        }

        public static string encode( string text ) {
            if ( text == String.Empty )
                return String.Empty;

            byte[] byteslog = Encoding.UTF8.GetBytes( text );
            string base64log = Convert.ToBase64String( byteslog );
            return base64log;
        }
    }
}
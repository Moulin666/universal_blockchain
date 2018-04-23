using System;
using System.Security.Cryptography;

namespace universal_blockchain.Encrypt
{
	public class RSA_encrypt
    {
		public static RSAParameters pubkey;
		public static RSAParameters privatekey;

		public static void initialize()
		{
			if (Settings.node.node_encrypt_key == "" || Settings.node.node_private_key == "")
			{
				var csp = new RSACryptoServiceProvider(2048);

                //how to get the private key
                var privKey = csp.ExportParameters(true);

                //and the public key ...
                var pubKey = csp.ExportParameters(false);

				pubkey = pubKey;
				privatekey = privKey;

				Settings.node.node_encrypt_key = KeyToString(pubkey);
				Settings.node.node_private_key = KeyToString(privatekey);
				Settings.save();
				
			}
			else
			{
				pubkey = KeyToParametrs(Settings.node.node_encrypt_key);
				privatekey = KeyToParametrs(Settings.node.node_private_key);

			}

            
		}

		public static string KeyToString(RSAParameters Key)
		{
			var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, Key);
            //get the string from the stream
            return sw.ToString();
  
		}
        
		public static RSAParameters KeyToParametrs(string KeyString)
		{
			var sr = new System.IO.StringReader(KeyString);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
  
		}

		public static string Encryption(string plainTextData)
        {
            try
            {
				var bsp = new RSACryptoServiceProvider();
				var csp = new RSACryptoServiceProvider();
				csp.ImportParameters(pubkey);
               
                //for encryption, always handle bytes...
				var bytesPlainTextData = System.Text.Encoding.UTF8.GetBytes(plainTextData);

                //apply pkcs#1.5 padding and encrypt our data 
                var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

                
				return Convert.ToBase64String(bytesCypherText);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

		public static string Encryption(string plainTextData,String node_pub_key)
        {
            try
            {
                var csp = new RSACryptoServiceProvider();
				csp.ImportParameters(KeyToParametrs(node_pub_key));

                //for encryption, always handle bytes...
                var bytesPlainTextData = System.Text.Encoding.UTF8.GetBytes(plainTextData);

                //apply pkcs#1.5 padding and encrypt our data 
                var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);


                return Convert.ToBase64String(bytesCypherText);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

		static public string Decryption(string encr_txt)
        {
            try
            {
				var bytesCypherText = Convert.FromBase64String(encr_txt);

                //we want to decrypt, therefore we need a csp and load our private key
                var csp = new RSACryptoServiceProvider();
				csp.ImportParameters(privatekey);

                //decrypt and strip pkcs#1.5 padding
                var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

                //get our original plainText back...
				return System.Text.Encoding.UTF8.GetString(bytesPlainTextData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
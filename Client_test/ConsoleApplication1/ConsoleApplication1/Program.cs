using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Ais.Net.Radius;
using Ais.Net.Radius.Attributes;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string user, password;

			// Populate it with your radius secret
			// Better if you get it from a config file
			const string radius_secret = "mysecretpassword";

			// Get my IP address to send it as a NasIP address
			// This is just for logging
            IPAddress a = IPAddress.Parse("46.160.161.182");
			IPHostEntry ip = Dns.GetHostEntry(a);
			
			string nasIp = ip.AddressList[0].ToString();

			// Get IP address for the radius server, you will
			// never know what's the answer from the global
			// load balancing system.
			string SecurePassRadius = "radius1.secure-pass.net";
			IPAddress[] addresslist = Dns.GetHostAddresses(SecurePassRadius);

			Console.WriteLine ("nWelcome to SecurePass .NET demo!");
			Console.WriteLine ("================================n");

			// Ask for username and password, i.e.
			// OTP + SecureFactor
			Console.Write("Username: ");
			user = Console.ReadLine ();

			Console.Write("Password: ");
			password = Console.ReadLine ();

			// Build a client with parameters
			var radiusClient = new Client(addresslist[0], 1812, radius_secret) {
				SendTimeout = 5000,
				ReceiveTimeout = 5000,
				Ttl = 50
			};

			// Create an access request
			var request = new AccessRequest(nasIp, ServiceType.Unknown, user,
                                                                            password, radiusClient);

			// Send with 3 retries
			var response = radiusClient.Send(request, true, 3);

			// Analyze the response packet
			if (response.Packet.PacketType == PacketType.AccessAccept)
				Console.WriteLine("Access granted");
			else
				Console.WriteLine("Access denied");

		}
	}

}
 
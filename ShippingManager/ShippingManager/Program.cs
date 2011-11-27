using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShippingManager
{
    static class Program
    {
        const string FileName = @"shippingSystem.bin";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShippingSystem shippingSystem;
            Stream fileStream;

            if (File.Exists(FileName))
            {
                fileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                shippingSystem = (ShippingSystem)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
            else
            {
                fileStream = File.Create(FileName);
                fileStream.Close();
                shippingSystem = new ShippingSystem();
                shippingSystem.addAdminEmployee("Lotar", "Hasani", "Walace", "lhwalace", "password");
                Console.WriteLine("Admins added");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(shippingSystem));

            fileStream = File.OpenWrite(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, shippingSystem);
            fileStream.Close();

        }
    }
}

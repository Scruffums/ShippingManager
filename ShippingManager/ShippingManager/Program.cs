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
            ShippingSystem ss;
            Stream TestFileStream;

            if (File.Exists(FileName))
            {
                TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                ss = (ShippingSystem)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }
            else
            {
                TestFileStream = File.Create(FileName);
                TestFileStream.Close();
                ss = new ShippingSystem();
                ss.addAdminEmployee("Lotar", "Hasani", "Walace", "lhwalace", "password");
                Console.WriteLine("Admins added");
            }
            
            ss.updateadjacency();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(ss));

            TestFileStream = File.OpenWrite(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, ss);
            TestFileStream.Close();

        }
    }
}

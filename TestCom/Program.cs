

using System;
using System.Runtime.InteropServices;

namespace TestCom
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Instantiate the COM object using the ProgID
                Type comType = Type.GetTypeFromProgID("HelloWorld");

                if (comType != null)
                {
                    // Create an instance of the COM object
                    dynamic comObject = Activator.CreateInstance(comType);

                    // Call the Start method and pass the name parameter
                    string name = "Jakob";  // Replace with the actual name you want to pass
                    string result = comObject.Start(name);  // Store the returned string (BSTR)

                    // Print the result
                    Console.WriteLine("Result from COM: " + result);

                    // Release the COM object when done
                    Marshal.ReleaseComObject(comObject);
                    comObject = null;
                }
                else
                {
                    Console.WriteLine("COM object not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

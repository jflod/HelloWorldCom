

using System;
using System.Runtime.InteropServices;




using System;
using System.Collections.Generic;
using System.Reflection;

namespace HelloWorldComTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string res = "4";

            var executeWrapper = new ComExecuteWrapper();

            executeWrapper.AddParameter("Jakob");
            res = executeWrapper.ExecuteMethod("HelloWorld", "Start");

            if (res == null)
            {
                Console.WriteLine("Error: Method call failed.");
                return;
            }
            else
                Console.WriteLine(res);
        }
    }

    internal sealed class ComExecuteWrapper
    {
        private readonly List<object> mArguments = new List<object>();
        private object mComComponent;
        private Type mComType;
        private string mProgId = "";

        public void AddParameter(object parameter) => this.mArguments.Add(parameter);

        public string ExecuteMethod(string progId, string method)
        {
            try
            {
                // Check if we are using the same ProgID, otherwise create a new COM object
                if (this.mProgId != progId)
                {
                    this.mComType = Type.GetTypeFromProgID(progId);
                    if (this.mComType == null)
                        throw new Exception($"Could not find COM type for ProgID [{progId}].");

                    this.mComComponent = Activator.CreateInstance(this.mComType);
                    if (this.mComComponent == null)
                        throw new Exception($"Could not create instance of COM component for ProgID '{progId}'.");

                    this.mProgId = progId;
                }

                // Convert arguments to array
                var arguments = this.mArguments.ToArray();

                // Invoke the method and return the result
                var result = this.mComType.InvokeMember(method, BindingFlags.InvokeMethod, null, this.mComComponent, arguments);
                return result?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing COM method: {ex.Message}");
                return null;
            }
        }
    }
}


//namespace TestCom
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                // Instantiate the COM object using the ProgID
//                Type comType = Type.GetTypeFromProgID("HelloWorld");

//                if (comType != null)
//                {
//                    // Create an instance of the COM object
//                    dynamic comObject = Activator.CreateInstance(comType);

//                    // Call the Start method and pass the name parameter
//                    string name = "Jakob";  // Replace with the actual name you want to pass
//                    string result = comObject.Start(name);  // Store the returned string (BSTR)

//                    // Print the result
//                    Console.WriteLine("Result from COM: " + result);

//                    // Release the COM object when done
//                    Marshal.ReleaseComObject(comObject);
//                    comObject = null;
//                }
//                else
//                {
//                    Console.WriteLine("COM object not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            Console.WriteLine("Press any key to exit...");
//            Console.ReadKey();
//        }
//    }
//}

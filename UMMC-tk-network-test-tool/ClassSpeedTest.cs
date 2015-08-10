using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Threading;




namespace UMMC_tk_network_test_tool
{
    class ClassSpeedTest
    {
        public List<String> runSpeedTest()
        {
            List<String> result = new List<string>();
            String path = @"pythonSpeedTest.py";
            var source = System.IO.File.ReadAllText(path);
            Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine();
            Microsoft.Scripting.Hosting.ScriptScope scope = py.CreateScope();
            var paths = py.GetSearchPaths();
            paths.Add(@"c:\Program Files (x86)\IronPython 2.7\Lib");
            py.SetSearchPaths(paths);
            try {
                py.Execute(source, scope);
                var download = scope.GetVariable("download");
                var upload = scope.GetVariable("upload");
                Console.WriteLine(download + "  ||  " + upload);
                result.Add(download);
                result.Add(upload);

            } catch (Exception ex) {
                Console.WriteLine("Problem with python: " + ex);
                return null;

            
            }



            return result;

        }
        
    }
}

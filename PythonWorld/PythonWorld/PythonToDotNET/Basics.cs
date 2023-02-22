
namespace PythonWorld.PythonToDotNET
{
    [TestClass]
    public class Basics : TestBase
    {
        public Basics()
        {
            CheckOrSetPythonEnvironmentVariable();

            PythonEngine.Initialize();
            //PythonEngine.ImportModule(name)
        }

        [TestMethod]
        public void Interaction_UsingOld()
        {
            using (Py.GIL())
            {
                PythonEngine.Exec("print('Hello, DOTNET from Python.')");
            }
        }
    }
}
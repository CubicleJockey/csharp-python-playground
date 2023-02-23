using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;
using PythonWorld.Models;

namespace PythonWorld.PythonToDotNET
{
    [TestClass]
    public class ObjectsToPython : TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            PythonEngine.Initialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            PythonEngine.Shutdown();
        }


        [DataRow(1, "André Davis")]
        [DataRow(2, "Wade Wilson")]
        [DataRow(3, "James Howlett")]
        [DataRow(4, "Luke Cage")]
        [DataTestMethod]
        public void DotNetObjectToPython(int id, string name)
        {
            var thingy = new Thingy { Id = id, Name = name };

            using var _ = Py.GIL();
            using var scope = Py.CreateScope();

            //Create Python variable 'thingy' with values of dotnet object thingy.
            PyObject thingyAsPyObject = thingy.ToPython();
            scope.Set("thingy", thingyAsPyObject);

            //Python code using the new variable.
            var code = "new_variable = f'ID: {thingy.Id}, Name: {thingy.Name}'";

            dynamic pyModule = scope.Exec(code);

            var expected = $"ID: {thingy.Id}, Name: {thingy.Name}";
            expected.Should().Be((string)pyModule.new_variable);
        }
    }
}


using System.Globalization;

namespace PythonWorld.PythonToDotNET;

[TestClass]
public class Basics : TestBase
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

    [TestMethod]
    public void Interaction_UsingOld()
    {
        using (Py.GIL())
        {
            PyObject result = PythonEngine.Eval("4 * 4");

            result.Should().NotBeNull();

            var expected = result.ToInt32(new NumberFormatInfo());
            expected.Should().Be(16);
        }
    }

    [TestMethod]
    public void Interaction_UsingModern()
    {
        using var _ = Py.GIL();
            
        PyObject result = PythonEngine.Eval("4 * 4");

        result.Should().NotBeNull();

        var expected = result.ToInt32(new NumberFormatInfo());
        expected.Should().Be(16);
            
    }

    [TestMethod]
    public void Interaction_NoUsing()
    {
        var gil = Py.GIL();

        try
        {
            PyObject result = PythonEngine.Eval("4 * 4");

            result.Should().NotBeNull();

            var expected = result.ToInt32(new NumberFormatInfo());
            expected.Should().Be(16);
        }
        finally
        {
            gil.Dispose();
        }

    }
}
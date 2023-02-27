namespace PythonWorld;

public abstract class TestBase
{
    private const string PYTHON = "PYTHONNET_PYDLL";

    protected TestBase()
    {

        var workingDirectory = Environment.CurrentDirectory;

        //const string INSTALLPATH = @"C:\Python310";
        var pythonNetPyDll = Environment.GetEnvironmentVariable(PYTHON);
        if (!string.IsNullOrWhiteSpace(pythonNetPyDll))
        {
            //return;
        }

        var dll = Path.Combine(workingDirectory, "Libs", "Python", "3.11.2", "python311.dll");
        Environment.SetEnvironmentVariable(PYTHON, dll);
    }
}
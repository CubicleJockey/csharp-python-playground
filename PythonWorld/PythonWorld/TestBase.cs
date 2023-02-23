namespace PythonWorld
{
    public abstract class TestBase
    {
        private const string PYTHON = "PYTHONNET_PYDLL";

        protected TestBase()
        {
            const string INSTALLPATH = @"C:\Python310";
            var pythonNetPyDll = Environment.GetEnvironmentVariable(PYTHON);
            if (!string.IsNullOrWhiteSpace(pythonNetPyDll))
            {
                return;
            }

            var dll = Path.Combine(INSTALLPATH, "python310.dll");
            Environment.SetEnvironmentVariable(PYTHON, dll);
        }
    }
}

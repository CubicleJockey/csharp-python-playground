namespace PythonWorld
{
    public abstract class TestBase
    {
        private const string PYTHON = "PYTHONNET_PYDLL";

        protected void CheckOrSetPythonEnvironmentVariable(string installPath = @"C:\Python310")
        {
            var pythonNetPyDll = Environment.GetEnvironmentVariable(PYTHON);
            if (!string.IsNullOrWhiteSpace(pythonNetPyDll)) { return; }

            var dll = Path.Combine(installPath, "python310.dll");
            Environment.SetEnvironmentVariable(PYTHON, dll);
        }
    }
}

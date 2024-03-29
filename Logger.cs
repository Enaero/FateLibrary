namespace Fate 
{
    public class Logger {
        private static Logger? _INSTANCE = null;

        public Action<string> PrintFunc;
        public Action<string> ErrorFunc;

        public static void INFO(string s) {
            GetLogger().PrintFunc(s);
        }

        public static void ERROR(string s) {
            GetLogger().ErrorFunc(s);
        }

        public static void SetPrintFunc(Action<string> printFunc) {
            GetLogger().PrintFunc = printFunc;
        }

        public static void SetErrorFunc(Action<string> errorFunc) {
            GetLogger().ErrorFunc = errorFunc;
        }

        private Logger() {
            PrintFunc = System.Console.WriteLine;
            ErrorFunc = System.Console.Error.WriteLine;
        }

        private static Logger GetLogger() {
            _INSTANCE ??= new();

            return _INSTANCE;
        }
    }
}
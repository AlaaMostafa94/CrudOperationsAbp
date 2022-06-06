using CrudOperations.Debugging;

namespace CrudOperations
{
    public class CrudOperationsConsts
    {
        public const string LocalizationSourceName = "CrudOperations";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2035cb92ca694ed0adb277e54dba4735";
    }
}

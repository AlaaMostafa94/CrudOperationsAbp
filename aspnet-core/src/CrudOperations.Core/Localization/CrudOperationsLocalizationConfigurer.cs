using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CrudOperations.Localization
{
    public static class CrudOperationsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CrudOperationsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CrudOperationsLocalizationConfigurer).GetAssembly(),
                        "CrudOperations.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

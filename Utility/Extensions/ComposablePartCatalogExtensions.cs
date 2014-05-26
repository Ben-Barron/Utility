using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;

namespace Utility.Extensions
{
    public static class ComposablePartCatalogExtensions
    {
        public static FilteredCatalog GetShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    (!d.Metadata.ContainsKey(CompositionConstants.PartCreationPolicyMetadataName) ||
                        ((CreationPolicy)d.Metadata[CompositionConstants.PartCreationPolicyMetadataName]) == CreationPolicy.Shared)
                    && !d.ExportDefinitions.Any(export => export.Metadata.ContainsKey("Scope")));
        }

        public static FilteredCatalog GetNonShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    d.Metadata.ContainsKeyValue(CompositionConstants.PartCreationPolicyMetadataName, CreationPolicy.NonShared) &&
                    !d.ExportDefinitions.Any(export => export.Metadata.ContainsKey("Scope")));
        }

        public static FilteredCatalog GetModuleShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    (!d.Metadata.ContainsKey(CompositionConstants.PartCreationPolicyMetadataName) ||
                        ((CreationPolicy)d.Metadata[CompositionConstants.PartCreationPolicyMetadataName]) == CreationPolicy.Shared)
                    && d.ExportDefinitions.Any(export => export.Metadata.ContainsKeyValue("Scope", "Module")));
        }

        public static FilteredCatalog GetModuleNonShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    d.Metadata.ContainsKeyValue(CompositionConstants.PartCreationPolicyMetadataName, CreationPolicy.NonShared) &&
                    d.ExportDefinitions.Any(export => export.Metadata.ContainsKeyValue("Scope", "Module")));
        }

        public static FilteredCatalog GetModuleInstanceShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    (!d.Metadata.ContainsKey(CompositionConstants.PartCreationPolicyMetadataName) ||
                        ((CreationPolicy)d.Metadata[CompositionConstants.PartCreationPolicyMetadataName]) == CreationPolicy.Shared)
                    && d.ExportDefinitions.Any(export => export.Metadata.ContainsKeyValue("Scope", "ModuleInstance")));
        }

        public static FilteredCatalog GetModuleInstanceNonShared(this ComposablePartCatalog catalog)
        {
            return new FilteredCatalog(catalog,
                d =>
                    d.Metadata.ContainsKeyValue(CompositionConstants.PartCreationPolicyMetadataName, CreationPolicy.NonShared) &&
                    d.ExportDefinitions.Any(export => export.Metadata.ContainsKeyValue("Scope", "ModuleInstance")));
        }

        public static void PrintExports(this ComposablePartCatalog catalog, string exportPrefix = "")
        {
            Debug.Print(string.Join(Environment.NewLine,
                catalog.SelectMany(
                    c =>
                        c.ExportDefinitions.Where(ed => ed.ContractName.StartsWith(exportPrefix))
                            .Select(fe => "EXPORT: " + fe.ContractName))));
        }

        public static void PrintImports(this ComposablePartCatalog catalog, string importPrefix = "")
        {
            Debug.Print(string.Join(Environment.NewLine,
                catalog.SelectMany(
                    c =>
                        c.ImportDefinitions.Where(ed => ed.ContractName.StartsWith(importPrefix))
                            .Select(fe => "IMPORT: " + fe.ContractName))));
        }
    }
}

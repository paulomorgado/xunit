﻿#if NETCOREAPP1_0

// Adapted from https://github.com/dotnet/core-setup/blob/652b680dff6b1afb9cd26cc3c2e883a664c209fd/src/managed/Microsoft.Extensions.DependencyModel/Resolution/ResolverUtils.cs

using System.IO;
using Microsoft.Extensions.DependencyModel;

namespace Xunit
{
    internal static class ResolverUtils
    {
        internal static bool TryResolvePackagePath(CompilationLibrary library, string basePath, out string packagePath)
        {
            var path = library.Path;
            if (string.IsNullOrEmpty(path))
                path = Path.Combine(library.Name, library.Version);

            packagePath = Path.Combine(basePath, path);

            return Directory.Exists(packagePath);
        }

        internal static bool TryResolveAssemblyFile(string basePath, string assemblyPath, out string fullName)
        {
            fullName = Path.Combine(basePath, assemblyPath);
            return File.Exists(fullName);
        }
    }
}

#endif

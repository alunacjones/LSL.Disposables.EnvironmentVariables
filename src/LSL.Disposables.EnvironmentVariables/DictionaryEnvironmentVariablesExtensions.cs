using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LSL.Disposables.EnvironmentVariables;

internal static class DictionaryEnvironmentVariablesExtensions
{
    public static IDictionary<string, string> ToStronglyTypedDictionary(this IDictionary source) =>
        source
            .Keys
            .OfType<string>()
            .ToDictionary(key => key, key => (string)source[key]);
}
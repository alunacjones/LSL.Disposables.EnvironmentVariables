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
            .Aggregate(
                new Dictionary<string, string>(),
                (agg, item) =>
                {
                    agg.Add(item, (string)source[item]);
                    return agg;
                });
}
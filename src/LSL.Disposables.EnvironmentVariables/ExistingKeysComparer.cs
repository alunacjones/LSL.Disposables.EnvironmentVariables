using System.Collections.Generic;
using System.Linq;

namespace LSL.Disposables.EnvironmentVariables;

internal class ExistingKeysComparer(IEnumerable<string> existingKeys) : IEqualityComparer<KeyValuePair<string, string>>
{
    public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y) => existingKeys.Any(e => e.Equals(x.Key));
    public int GetHashCode(KeyValuePair<string, string> obj) => obj.Key.GetHashCode();
}
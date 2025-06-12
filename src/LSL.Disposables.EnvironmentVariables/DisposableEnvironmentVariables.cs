using System;
using System.Collections.Generic;
using System.Linq;

namespace LSL.Disposables.EnvironmentVariables;

/// <summary>
/// On creation of this disposable
/// it will create a snapshot of the
/// current environment variables and
/// then restore the environment variables
/// on disposal. This includes removing any created
/// environment variables and reinstating any deleted ones.
/// </summary>
public class DisposableEnvironmentVariables : IDisposable
{
    private bool _disposedValue;
    private IDictionary<string, string> _snapshot;

    /// <summary>
    /// On construction, a snapshot of all the 
    /// current environment variables is taken.
    /// On disposal of the instance, all
    /// environment variables are restored to the original
    /// set.
    /// </summary>
    public DisposableEnvironmentVariables() => _snapshot = Environment.GetEnvironmentVariables().ToStronglyTypedDictionary();

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                ResetEnvironmentVariables();
            }

            _disposedValue = true;
        }
    }

    private void ResetEnvironmentVariables()
    {
        foreach (var keyValuePair in _snapshot)
        {
            Environment.SetEnvironmentVariable(keyValuePair.Key, _snapshot[keyValuePair.Key]);
        }

        Environment
            .GetEnvironmentVariables()
            .ToStronglyTypedDictionary()
            .Except(_snapshot, new ExistingKeysComparer(_snapshot.Keys))
            .ToList()
            .ForEach(kvp => Environment.SetEnvironmentVariable(kvp.Key, null));
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

using System;
using UniRx;

public class Disposer : IDisposable
{
    public readonly CompositeDisposable disposables = new();

    public void Dispose()
    {
        disposables.Dispose();
    }
}

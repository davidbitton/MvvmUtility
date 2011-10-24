using System.ComponentModel.Composition;

namespace MvvmUtility.Infrastructure.StateManagement {
    [InheritedExport]
    public interface IState<T> {
        T Value { get; }
    }
}
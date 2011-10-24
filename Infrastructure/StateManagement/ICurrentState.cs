using System.ComponentModel.Composition;

namespace MvvmUtility.Infrastructure.StateManagement {
    [InheritedExport]
    public interface ICurrentState<T> {
        T Value { get; set; }
    }
}
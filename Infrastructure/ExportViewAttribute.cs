using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace MvvmUtility.Infrastructure {
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportViewAttribute : ExportAttribute {
        public ExportViewAttribute(string viewName) : base(viewName, typeof (UserControl)) {
        }
    }
}
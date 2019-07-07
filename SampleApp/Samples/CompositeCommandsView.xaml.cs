﻿namespace SampleApp.Samples
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;

    using JetBrains.Annotations;

    using TomsToolbox.Wpf;
    using TomsToolbox.Wpf.Composition.Mef;

    /// <summary>
    /// Interaction logic for CompositeCommandsView.xaml
    /// </summary>
    [DataTemplate(typeof(CompositeCommandsViewModel))]
    public partial class CompositeCommandsView
    {
        [ImportingConstructor]
        public CompositeCommandsView([CanBeNull] IExportProvider exportProvider)
        {
            this.SetExportProvider(exportProvider);

            InitializeComponent();
        }
    }
}

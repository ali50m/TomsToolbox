﻿namespace SampleApp.Mef2.Samples
{
    using System.Windows;
    using System.Windows.Input;

    using JetBrains.Annotations;

    using PropertyChanged;

    using TomsToolbox.Wpf;
    using TomsToolbox.Wpf.Composition.Mef2;

    [VisualCompositionExport(RegionId.CommandViewContainer)]
    [ImplementPropertyChanged]
    class CompositeCommandChild2ViewModel
    {
        [CanBeNull]
        public string Text { get; set; } = "Greetings from child #2";

        [NotNull]
        public ICommand CopyCommand => new DelegateCommand(() => MessageBox.Show("Copy: " + Text));

        [NotNull]
        public ICommand PasteCommand => new DelegateCommand(() => MessageBox.Show("Paste: " + Text));

        [NotNull]
        public ICommand CutCommand => new DelegateCommand(() => MessageBox.Show("Cut: " + Text));
    }
}

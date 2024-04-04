using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Jewelry.View
{
    /// <summary>
    /// Логика взаимодействия для AnalyzeView.xaml
    /// </summary>
    public partial class AnalyzeView : UserControl
    {
        public AnalyzeView()
        {
            InitializeComponent();
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CB.ItemsSource != null)
            {
                CB.IsDropDownOpen = true;
                // убрать selection, если dropdown только открылся
                var tb = (TextBox)e.OriginalSource;
                tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
                CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(CB.ItemsSource);
                cv.Filter = s => ((string)s).IndexOf(CB.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }
    }
}

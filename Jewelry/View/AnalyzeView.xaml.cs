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
            var comboBox = sender as ComboBox;

            if (comboBox.ItemsSource != null)
            {
                comboBox.IsDropDownOpen = true;
                // убрать selection, если dropdown только открылся
                var tb = (TextBox)e.OriginalSource;
                tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
                CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(comboBox.ItemsSource);
                cv.Filter = s => ((string)s).IndexOf(comboBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Грубо_говоря_электронный_дневник_1;

namespace DiaryApp
{
    public partial class MainWindow : Window
    {
        DiaryDBEntitie db = new DiaryDBEntitie();
        List<DiaryView> data;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            data = db.DiaryView.ToList();
            dgDiary.ItemsSource = data;
        }

        void ApplyFilter()
        {
            var q = data.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtStudent.Text))
                q = q.Where(x => x.Ученик.Contains(txtStudent.Text));

            if (!string.IsNullOrWhiteSpace(txtSubject.Text))
                q = q.Where(x => x.Предмет.Contains(txtSubject.Text));

            dgDiary.ItemsSource = q.ToList();
        }

        private void Filter_Changed(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void BtnSortAsc_Click(object sender, RoutedEventArgs e)
        {
            dgDiary.ItemsSource = data.OrderBy(x => x.Ученик).ToList();
        }

        private void BtnSortDesc_Click(object sender, RoutedEventArgs e)
        {
            dgDiary.ItemsSource = data.OrderByDescending(x => x.Ученик).ToList();
        }
    }
}

using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WpfApp1.MainWindow;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Todo> Todos { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Todos = new ObservableCollection<Todo>();
            lst_Todo.ItemsSource = Todos;
        }
        public class Todo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                int newId = Todos.Any() ? Todos.Max(t => t.ID) + 1 : 1;
                Todo newTodo = new Todo { ID = newId, Name = txt_Name.Text };
                Todos.Add(newTodo);
                txt_Name.Clear();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên kìa.");
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            // Lấy Todo được chọn từ ListView
            Todo selectedTodo = (Todo)lst_Todo.SelectedItem;

            if (selectedTodo != null)
            {
                // Xóa Todo khỏi danh sách
                Todos.Remove(selectedTodo);
            }
            else
            {
                MessageBox.Show("Bạn chọn dữ liệu cần xoá đi.");
            }
        }
    }
}
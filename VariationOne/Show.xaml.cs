using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace VariationOne
{
    public partial class Show : Page
    {
        Users_ToyStore use = new Users_ToyStore();
        public Show(Users_ToyStore user)
        {
            InitializeComponent();
            use = user;

            CurrentPageAgents = new ObservableCollection<Agent>();
            PageNumbers = new ObservableCollection<int>();
            LoadData();

            switch (user.user_id_role)
            {
                case 1:
                    //админ всё доступно
                    addConMenu.IsEnabled = true;
                    editConMenu.IsEnabled = true;
                    delConMenu.IsEnabled = true;

                    addButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    delButton.IsEnabled = true;
                    break;
                case 2:
                    //пользователь
                    addConMenu.IsEnabled = false;
                    editConMenu.IsEnabled = false;
                    delConMenu.IsEnabled = false;
                    addConMenu.Visibility = Visibility.Collapsed;
                    editConMenu.Visibility = Visibility.Collapsed;
                    delConMenu.Visibility = Visibility.Collapsed;

                    addButton.IsEnabled = false;
                    editButton.IsEnabled = false;
                    delButton.IsEnabled = false;
                    addButton.Visibility = Visibility.Collapsed;
                    editButton.Visibility = Visibility.Collapsed;
                    delButton.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    //менеджер
                    addConMenu.IsEnabled = true;
                    editConMenu.IsEnabled = true;
                    delConMenu.IsEnabled = true;

                    addButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    delButton.IsEnabled = true;
                    break;
                default:
                    MessageBox.Show("Произошла какая-то ошибка с данными пользователя. Вас перекинут на страницу авторизации.", "О-оу", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

            Sorter.Items.Add("Все типы");
            
            for (int i = 0; i < AppConnect.entities.AgentType.ToList().Count; i++)
            {
                Sorter.Items.Add(AppConnect.entities.AgentType.ToList()[i]);
            }
            Sorter.SelectedIndex = 0;

            //фильтр
            Filter.ItemsSource = new Filt[]
            {
                new Filt { Name_filter = "Фильтрация" },
                new Filt { Name_filter = "Наименование" },
                new Filt { Name_filter = "Размер скидки" },
                new Filt { Name_filter = "Приоритет агента" }
            };
            Filter.SelectedIndex = 0;

            //список
            listProducts.ItemsSource = FindProduct(pageNumber);
            //var currentPageAgents = FindProduct(pageNumber);
            this.use = use;
        }

        public class Sort
        {
            public string Name_sorter { get; set; } = "";
            public override string ToString() => $"{Name_sorter}";
        }

        public class Filt
        {
            public string Name_filter { get; set; } = "";
            public override string ToString() => $"{Name_filter}";
        }

        private int _pageNumber = 1;
        private int _totalPages;

        public ObservableCollection<Agent> CurrentPageAgents { get; set; }
        public ObservableCollection<int> PageNumbers { get; set; }
        public int SelectedPage { get; set; }
        private void LoadData()
        {
            var products = AppConnect.entities.Agent.ToList();
            _totalPages = (int)Math.Ceiling(products.Count / (double)10);

            for (int i = 1; i <= _totalPages; i++)
            {
                PageNumbers.Add(i);
            }

            SelectedPage = _pageNumber;
            CurrentPageAgents.Clear();
            //CurrentPageAgents.AddRange(FindProduct(_pageNumber));

            listProducts.Items.Clear();
            //listProducts.ItemsSource = CurrentPageAgents.Add(FindProduct(_pageNumber));
            listProducts.ItemsSource = FindProduct(_pageNumber);
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber > 1)
            {
                _pageNumber--;
                LoadData();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber < _totalPages)
            {
                _pageNumber++;
                LoadData();
            }
        }

        int pageSize = 10;
        int pageNumber = 1;

        //составление списка
        Agent[] FindProduct(int pageNumber)
        {
            var products = AppConnect.entities.Agent.ToList();
            var producttall = products;

            var totalPages = (int)Math.Ceiling(products.Count / (double)pageSize); //

            if (Searcher.Text != null)
            {
                products = products.Where(x => x.Title.ToLower().Contains(Searcher.Text.ToLower()) || x.Phone.ToLower().Contains(Searcher.Text.ToLower()) || x.Email.ToLower().Contains(Searcher.Text.ToLower())).ToList();
            }

            if (Filter.SelectedIndex > 0)
            {
                switch (Filter.SelectedIndex)
                {
                    case 1:
                        products = products.OrderBy(x => x.Title).ToList();
                        break;
                    case 2:
                        products = products.OrderBy(x => x.INN).ToList();
                        break;
                    case 3:
                        products = products.OrderBy(x => x.Priority).ToList();
                        break;
                }
            }

            if (Sorter.SelectedIndex > 0)
            {
                products = products.Where(x => x.AgentTypeID == Sorter.SelectedIndex).ToList();
            }

            if (products.Count > 0)
            {
                Counter.Content = $"Найдено {products.Count} из {producttall.Count} товаров.";
            }
            else
            {
                Counter.Content = "Ничего не найдено.";
            }
            // Calculate the start and end indices for the current page
            var startIndex = (pageNumber - 1) * pageSize;
            var endIndex = startIndex + pageSize;

            // Return the agents for the current page
            var currentPageAgents = products.Skip(startIndex).Take(pageSize).ToArray();

            return currentPageAgents.ToArray();
            //return products.ToArray();
        }

        //кнопка возвращения назад
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        //обновление страницы
        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listProducts.ItemsSource = FindProduct(pageNumber);
            //var currentPageAgents = FindProduct(pageNumber);
        }

        //обновление страницы
        private void Sorter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listProducts.ItemsSource = FindProduct(pageNumber);
            //var currentPageAgents = FindProduct(pageNumber);
        }

        //обновление страницы
        private void Searcher_TextChanged(object sender, TextChangedEventArgs e)
        {
            listProducts.ItemsSource = FindProduct(pageNumber);
            //var currentPageAgents = FindProduct(pageNumber);
        }

        //добавление товара через кнопку
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            addFun();
        }

        //редактирование товара через кнопку
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            editFun();
        }

        //удаление товара через кнопку
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            delFun();
        }

        //обновление контента на странице
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AppConnect.entities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                listProducts.ItemsSource = AppConnect.entities.Agent.ToList();
            }
        }

        //добавить товар через админа
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addFun();
        }

        //редактировать товар через админа
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Agent)listProducts.SelectedItem != null)
            {
                editFun();
            }
        }

        //удаление товара через админа
        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Agent)listProducts.SelectedItem != null)
            {
                delFun();
            }
        }

        //Переход на добавление товара через контекстное меню через админа
        private void addFun()
        {
            AppFrame.frameMain.Navigate(new AddRed(null, use));
        }

        //Переход на редактирование товара через контекстное меню через админа
        private void editFun()
        {
            Agent red = (Agent)listProducts.SelectedItem;
            AppFrame.frameMain.Navigate(new AddRed(red, use));
        }

        //Удаление товара через контекстное меню через админа
        private void delFun()
        {
            var del = (Agent)listProducts.SelectedItem;
            var res = MessageBox.Show($"Вы действительно хотите удалить этот товар?\n Будет удалён:\nНаименование: \nАртикль: \n", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.entities.Agent.Remove(del);
                    AppConnect.entities.SaveChanges();
                    listProducts.ItemsSource = FindProduct(pageNumber);
                    //var currentPageAgents = FindProduct(pageNumber);
                    //MessageBox.Show("Данные успешно удалены", "Тестирование", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Searcher_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Searcher.Text))
            {
                Searcher.Visibility = Visibility.Collapsed;
                SearcherPlaceHolder.Visibility = Visibility.Visible;
            }
        }

        private void SearcherPlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            SearcherPlaceHolder.Visibility = Visibility.Collapsed;
            Searcher.Visibility = Visibility.Visible;
            Searcher.Focus();
        }
    }
}

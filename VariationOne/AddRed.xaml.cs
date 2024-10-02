using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VariationOne
{
    public partial class AddRed : Page
    {
        private Agent _curAgent = new Agent();
        Users_ToyStore use = new Users_ToyStore();
        public AddRed(Agent aget, Users_ToyStore user)
        {
            InitializeComponent();
            use = user;

            Combo_names.Items.Add("-выбрать-");

            //заполнение списка категорий
            for (int i = 0; i < AppConnect.entities.AgentType.ToList().Count; i++)
            {
                Combo_names.Items.Add(AppConnect.entities.AgentType.ToList()[i]);
            }

            if (aget != null)
            {
                _curAgent = aget;
                Title = "Редактирование";
                Red.IsEnabled = true;

                check(article, articlePlaceHolder);
                check(prize, prizePlaceHolder);
                check(image, imagePlaceHolder);

            }
            else
            {
                Title = "Добавление";
                Red.IsEnabled = false;
                Red.Visibility = Visibility.Collapsed;
            }

            DataContext = _curAgent;
        }

        //вернуться
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        //к магазину
        private void list_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Show(use));
        }

        //добавить товар
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Combo_names.SelectedIndex != 0 && article.Text != "")
            {
                var res = MessageBox.Show("Вы действительно хотите добавить этот товар?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        AppConnect.entities.Agent.Add(_curAgent);
                        AppConnect.entities.SaveChanges();
                        MessageBox.Show("Данные успешно добавленны", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppFrame.frameMain.Navigate(new Show(use));
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все необходимые поля!", "Уведомлениее", MessageBoxButton.OK);
            }
        }

        //редактировать товар
        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (Combo_names.SelectedIndex != 0)
            {
                var res = MessageBox.Show("Вы действительно хотите редактировать этот товар?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (res == MessageBoxResult.Yes)
                {
                    try
                    {

                        AppConnect.entities.SaveChanges();
                        MessageBox.Show("Данные успешно редактированы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        AppFrame.frameMain.Navigate(new Show(use));
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все необходимые поля!", "Уведомлениее", MessageBoxButton.OK);
            }
        }

        private void article_LostFocus(object sender, RoutedEventArgs e)
        {
            check(article, articlePlaceHolder);
            placeHolder(article, articlePlaceHolder);
        }

        private void articlePlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            Original(article, articlePlaceHolder);
            article.Focus();
        }

        private void prize_LostFocus(object sender, RoutedEventArgs e)
        {
            check(prize, prizePlaceHolder);
            placeHolder(prize, prizePlaceHolder);
        }

        private void prizePlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            Original(prize, prizePlaceHolder);
            prize.Focus();
        }

        private void image_LostFocus(object sender, RoutedEventArgs e)
        {
            check(image, imagePlaceHolder);
            placeHolder(image, imagePlaceHolder);
        }

        private void imagePlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            Original(image, imagePlaceHolder);
            image.Focus();
        }

        private void Original(TextBox org, TextBox place)
        {
            place.Visibility = Visibility.Collapsed;
            org.Visibility = Visibility.Visible;
        }

        private void placeHolder(TextBox org, TextBox place)
        {
            if (string.IsNullOrEmpty(org.Text))
            {
                org.Visibility = Visibility.Collapsed;
                place.Visibility = Visibility.Visible;
            }
        }

        private void check(TextBox org, TextBox place)
        {
            if (org.Text == null)
            {
                placeHolder(org, place);
            }
            else
            {
                Original(org, place);
            }
        }
    }
}

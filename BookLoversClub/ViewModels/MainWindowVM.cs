using BookLoversClub.Core;
using BookLoversClub.DataBase;
using BookLoversClub.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookLoversClub.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        BookLoversClubContext db = new BookLoversClubContext();

        //коллекция с книгами
        public List<Book> Books { get; set; }

        private ObservableCollection<BookOrder> bookOrders;
        public ObservableCollection<BookOrder> BookOrders 
        { 
            get => bookOrders; 
            set
            {
                bookOrders = value;
                SignalChanged();
            }
        }

        public Visibility boolShowOrder = Visibility.Collapsed;
        public Visibility BoolShowOrder
        {
            get => boolShowOrder;
            set
            {
                boolShowOrder = value;
                SignalChanged();
            }
        }

        private Book selectedBook { get; set; }
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                SignalChanged();
            }

        }

        public CustomCommand AddBookToOrder { get; set; }
        public CustomCommand ShowOrder { get; set; }

        public MainWindowVM()
        {
            Books = new List<Book>(db.Books.Include(s => s.IdProductionNavigation).ToList());

            BookOrders = new ObservableCollection<BookOrder>();

            AddBookToOrder = new CustomCommand(() =>
            {
                try
                {
                    if (SelectedBook != null)
                    {
                        BookOrders.Add(new BookOrder
                        {
                            IdBook = selectedBook.Id,
                            Count = 1,
                            IdBookNavigation = SelectedBook
                        });
                    }
                    BoolShowOrder = Visibility.Visible;
                    MessageBox.Show("товар добавлен к заказу");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            });

            /*
             * 
             * 192.168.??.??:3000
Git clone
cd ...
Git status
Git add .
Git commit -m "comment"
Git push origin master
             Ветка
Git checkout -b session1
Изменяем файлы
Git status
Git add .
Git commit -m "13"
Git push origin session 1

Связать с мастер
Git checkout master
git merge session1
Git push origin master
Панель управления
Все элементы панели управления
Диспетчер учётных данных
Учётные данные Windows
Грохаем старый

            //cd c/users...
            
            //git init
            //git add .
            //
            // git commit -m' first commit'
            //

            */
            //Scaffold-DbContext "Integrated Security=True; Server=DESKTOP-G64T7H2\SQLEXPRESS; Initial Catalog= BigPack;" -OutputDir db -Provider Microsoft.EntityFrameworkCore.SqlServer;
            ShowOrder = new CustomCommand(() =>
            {
                OrderListWindow orderListWindow = new OrderListWindow(BookOrders);
                orderListWindow.ShowDialog();
            });
        }

    }
}

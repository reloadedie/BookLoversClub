using BookLoversClub.Core;
using BookLoversClub.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookLoversClub.ViewModels
{
    public class OrderListWindowVM : BaseViewModel
    {
        public ObservableCollection<BookOrder> BookOrdersList
        { 
            get => bookOrders; 
            set
            {
                bookOrders = value;
                SignalChanged();
            }
        }

        private BookOrder selectedBookInOrderList { get; set; }
        public BookOrder SelectedBookInOrderList
        {
            get => selectedBookInOrderList;
            set
            {
                selectedBookInOrderList = value;
                SignalChanged();
            }

        }

        private decimal? sumSaleCost;
        public decimal? SumSaleCost
        {
            get => sumSaleCost;
            set
            {
                sumSaleCost = value;
                SignalChanged();
            }
        }

        private ObservableCollection<BookOrder> bookOrders;

        private decimal sumOrderCost;
        public decimal SumOrderCost
        {
            get => sumOrderCost;
            set
            {
                sumOrderCost = value;
                SignalChanged();
            }
        }

        public CustomCommand DeleteBookInListOrder { get; set; }

        public OrderListWindowVM(ObservableCollection<BookOrder> bookOrders)
        {
            BookOrdersList = new ObservableCollection<BookOrder>(bookOrders);

            SumOrderCost = BookOrdersList.Sum(s => s.IdBookNavigation.Cost);
            SumSaleCost = BookOrdersList.Sum(s => s.IdBookNavigation.SaleCost);

            DeleteBookInListOrder = new CustomCommand(() =>
            {
                try
                {
                    BookOrdersList.Remove(SelectedBookInOrderList);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                SumOrderCost = BookOrdersList.Sum(s => s.IdBookNavigation.Cost);
                SumSaleCost = BookOrdersList.Sum(s => s.IdBookNavigation.SaleCost);
            });
        }


    }
}

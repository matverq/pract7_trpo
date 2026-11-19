using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pract7_trpo.Models
{
    public class HotelBooking : INotifyPropertyChanged
    {
        private string _guestName = "Иванов Иван";
        public string GuestName
        {
            get => _guestName;
            set { if (_guestName != value) { _guestName = value; OnPropertyChanged(); } }
        }

        private decimal _pricePerNight = 5000m;
        public decimal PricePerNight
        {
            get => _pricePerNight;
            set
            {
                if (_pricePerNight != value)
                {
                    _pricePerNight = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private int _nights = 3;
        public int Nights
        {
            get => _nights;
            set
            {
                if (_nights != value)
                {
                    _nights = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private decimal? _discount = 0.1m;
        public decimal? Discount
        {
            get => _discount;
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public decimal TotalPrice
        {
            get
            {
                var total = PricePerNight * Nights;
                var discountAmount = total * (Discount ?? 0);
                return total - discountAmount;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

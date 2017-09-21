
using CrossPlattformLib.Model;
using System.Collections.Generic;


namespace CrossPlattformLib.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private List<Customer> _customers;
        private Customer _currentCustomer;
        private CustomerRepository _repository;

        public CustomerViewModel()
        {
            _repository = new CustomerRepository();
            _customers = _repository.GetCustomers();

            WireCommands();
        }

        private void WireCommands()
        {
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
        }

        public RelayCommand UpdateCustomerCommand
        {
            get;
            private set;
        }

        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }

            set
            {
                if (_currentCustomer != value)
                {
                    _currentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");
                    UpdateCustomerCommand.IsEnabled = true;
                }
            }
        }

        public void UpdateCustomer()
        {
            _repository.UpdateCustomer(CurrentCustomer);
        }
    }
}

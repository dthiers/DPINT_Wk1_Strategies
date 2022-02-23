using DPINT_Wk1_Strategies.NumberConverterStrategies;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {

        private NumberConverterFactory _numberConverterFactory;

        public ValueConverterViewModel()
        {
            _numberConverterFactory = new NumberConverterFactory();
            ConverterNames = new ObservableCollection<string>(_numberConverterFactory.ConverterNames);

            _fromText = "0";
            _toText = "0";
            _fromConverterName = "Numerical";
            _toConverterName = "Numerical";
            
            _fromConverter = _numberConverterFactory.GetConverter(_fromConverterName);
            _toConverter = _numberConverterFactory.GetConverter(_toConverterName);


            ConvertCommand = new RelayCommand(ConvertNumbers);
        }

        private void ConvertNumbers()
        {
            var number = _fromConverter.ToNumerical(FromText);
            ToText = _toConverter.ToLocalString(number);
        }

        #region properties
        /// <summary>
        /// ItemSource ComboBox cBox_From, cBox_To
        /// </summary>
        public ObservableCollection<string> ConverterNames { get; set; }
        public ICommand ConvertCommand { get; set; }


        /// <summary>
        /// INumberConverter From
        /// </summary>
        private INumberConverter _fromConverter;
        public INumberConverter FromConverter
        {
            get { return _fromConverter; }
            set { _fromConverter = value; }
        }

        /// <summary>
        /// INumberConverter To
        /// </summary>
        private INumberConverter _toConverter;
        public INumberConverter ToConverter
        {
            get { return _toConverter; }
            set { _toConverter = value; }
        }


        /// <summary>
        /// TextBox 
        /// </summary>
        private string _fromText;
        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
                this.ConvertNumbers();
            }
        }

        /// <summary>
        /// TextBox
        /// </summary>
        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        /// <summary>
        /// ComboBox
        /// </summary>
        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                FromConverter = _numberConverterFactory.GetConverter(value);
                RaisePropertyChanged("FromConverterName");
                ConvertNumbers();
            }
        }

        /// <summary>
        /// ComboBox
        /// </summary>
        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                _toConverter = _numberConverterFactory.GetConverter(value);
                RaisePropertyChanged("ToConverterName");
                this.ConvertNumbers();
            }
        }
        #endregion
    }
}

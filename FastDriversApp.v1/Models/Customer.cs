using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _customerId;
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _email;
        private string _phone;
        private string _licenceNumber;
        private string _password;
        private DateTime _dob;
        private string _ccName;
        private string _ccNumber;
        private int _ccExpiryMonth;
        private int _ccExpiryYear;
        private int _ccCVV;
        private SQLHelper _db;
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Error
        {
            get { return null; }
        }

        // When creating a new Job make sure that your job can only be booked for the future date.
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(this.FirstName))
                        {
                            result = "First name cannot be left empty!";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(this.FirstName))
                        {
                            result = "Last name cannot be left empty!";
                        }
                        break;
                    case "Dob":
                        if (Dob > DateTime.Now)
                        {
                            result = "Your DOB cannot be in the future!";
                        }
                        break;
                }
                if (result != null)
                {
                    //ErrorCollection.Add(propertyName, result);
                    // Avoids "duplicate key" error
                    ErrorCollection[propertyName] = result;
                }
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }

        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set { _fullName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string LicenceNumber
        {
            get { return _licenceNumber; }
            set
            {
                _licenceNumber = value;
                OnPropertyChanged("LicenceNumber");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public DateTime Dob
        {
            get { return _dob; }
            set 
            { 
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }

        public string CCName
        {
            get { return _ccName; }
            set
            {
                _ccName = value;
                OnPropertyChanged("CCName");
            }
        }
        public string CCNumber
        {
            get { return _ccNumber; }
            set
            {
                _ccNumber = value;
                OnPropertyChanged("CCNumber");
            }
        }
        public int ExpiryMonth
        {
            get { return _ccExpiryMonth; }
            set
            {
                _ccExpiryMonth = value;
                OnPropertyChanged("ExpiryMonth");
            }
        }
        public int ExpiryYear
        {
            get { return _ccExpiryYear; }
            set
            {
                _ccExpiryYear = value;
                OnPropertyChanged("ExpiryYear");
            }
        }
        public int CVV
        {
            get { return _ccCVV; }
            set
            {
                _ccCVV = value;
                OnPropertyChanged("CVV");
            }
        }
        public Customer(bool createHelper = true)
        {
            if (createHelper) 
                _db = new SQLHelper();
            
        }
        private void GeneratePassword()
        {
            this.Password = "welcome";
        }
        public Customer(DataRow dr)
        {
            _db = new SQLHelper();
            this.CustomerId = Convert.ToInt32(dr["customerId"].ToString());
            this.FirstName = dr["firstName"].ToString();
            this.LastName = dr["lastName"].ToString();
            this.LicenceNumber = dr["licenceNumber"].ToString();
            this.Phone = dr["phone"].ToString();
            this.Email = dr["email"].ToString();
        }
        public string InsertCustomer()
        {
            GeneratePassword();
            string sql = "INSERT INTO CUSTOMER(firstName, lastName, licenceNumber, email, phone, street, suburb," +
                " postcode, state, dob, ccName, ccNumber, ccExpiryMonth, ccExpiryYear, CVV, password) " +
                " VALUES(@FirstName, @LastName, @LicenceNumber, @Email, @Phone, @Street, @Suburb, " +
                " @PostCode, @State, @Dob, @CCName, @CCNumber, @CCExpiryMonth, @CCExpiryYear, @Cvv, @Password)";
            SqlParameter[] objParams = new SqlParameter[16];
            objParams[0] = new SqlParameter("@FirstName", DbType.String);
            objParams[0].Value = this.FirstName;
            objParams[1] = new SqlParameter("@LastName", DbType.String);
            objParams[1].Value = this.LastName;
            objParams[2] = new SqlParameter("@LicenceNumber", DbType.String);
            objParams[2].Value = this.LicenceNumber;
            objParams[3] = new SqlParameter("@Email", DbType.String);
            objParams[3].Value = this.Email;
            objParams[4] = new SqlParameter("@Phone", DbType.String);
            objParams[4].Value = this.Phone;
            objParams[5] = new SqlParameter("@Street", DbType.String);
            objParams[5].Value = this.Street;
            objParams[6] = new SqlParameter("@Suburb", DbType.String);
            objParams[6].Value = this.Suburb;
            objParams[7] = new SqlParameter("@PostCode", DbType.String);
            objParams[7].Value = this.PostCode;
            objParams[8] = new SqlParameter("@State", DbType.String);
            objParams[8].Value = this.State;
            objParams[9] = new SqlParameter("@Dob", DbType.DateTime);
            objParams[9].Value = this.Dob;
            objParams[10] = new SqlParameter("@CCName", DbType.String);
            objParams[10].Value = this.CCName;
            objParams[11] = new SqlParameter("@CCNumber", DbType.String);
            objParams[11].Value = this.CCNumber;
            objParams[12] = new SqlParameter("@CCExpiryMonth", DbType.Int32);
            objParams[12].Value = this.ExpiryMonth;
            objParams[13] = new SqlParameter("@CCExpiryYear", DbType.Int32);
            objParams[13].Value = this.ExpiryYear;
            objParams[14] = new SqlParameter("@Cvv", DbType.Int32);
            objParams[14].Value = this.CVV;
            objParams[15] = new SqlParameter("@Password", DbType.String);
            objParams[15].Value = this.Password;
            int rowsAffected = _db.ExecuteNonQuery(sql, objParams);
            if (rowsAffected >= 1)
            {
                return "New customer registered successfully!";
            }
            return "New customer registration was not successful, please try again!";
        }
    }
}

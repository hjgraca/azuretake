using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Entities
{
    public class PostCodeEntity : TableEntity
    {
        private string _postCode;
        private string _name;

        public string PostCode
        {
            get { return _postCode; }
            set
            {
                this.PartitionKey = value;
                _postCode = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                this.RowKey = value;
                _name = value;
            }
        }

        public string Region { get; set; }
    }
}

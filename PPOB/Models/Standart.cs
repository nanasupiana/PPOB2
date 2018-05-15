using System.Data.SqlClient;

namespace PPOB.Models
{

    public class StandartComboBox
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

    public class TransactionHelper
    {
        SqlCommand _Cmd = new SqlCommand();
        public SqlCommand Command
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
    }
    public class FilePath
    {
        public const string FilePathExcel = "~/Content/Excel/";
        public const string FilePathSlider = "~/Content/Slider/";
    }
}

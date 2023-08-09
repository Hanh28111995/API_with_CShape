namespace wcl_employee_admin.ViewModel
{
    public class ResultFeedBack
    {
        public bool Action_Result { get; set; }
        public string Message { get; set; }
        public string token_user { get; set; }

        public DataUser dataUser { get; set; }

    }
    public class DataUser
    {
        public string Username { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ExpTokenDate { get; set; }

    }
}

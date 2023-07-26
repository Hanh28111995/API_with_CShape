namespace wcl_employee_admin.Data
{
    public class UserForm
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        public int? Dkp { get; set; } = 0;
        public int? Vha { get; set; } = 0;



    }
}

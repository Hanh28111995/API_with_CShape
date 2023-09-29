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
        public string Avatarurl { get; set; }
        public string ExpTokenDate { get; set; }

    }
    public class ObjectPending
    {
        public int CoWorkerPending { get; set; }
        public int PendingTimeOff { get; set; }
        public int PendingMissPunch { get; set; }
        public int PendingLunchCorrection { get; set; }
        public int PendingIncidentReport { get; set; }
        public int PendingEmployeeComplaint { get; set; }
        public int PendingVTO { get; set; }
        public int PendingInjuryReport { get; set; }
    }
}

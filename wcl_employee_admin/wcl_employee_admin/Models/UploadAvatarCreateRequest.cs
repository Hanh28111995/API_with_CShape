namespace wcl_employee_admin.Models
{
    public class UploadAvatarCreateRequest
    {
        public IFormFile Avatar { set; get; }
        public string UserName { set; get; }
    }
}

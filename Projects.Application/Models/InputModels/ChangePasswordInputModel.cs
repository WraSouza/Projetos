namespace Projects.Application.Models.InputModels
{
    public class ChangePasswordInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}

namespace SweetIncApi.Models.DTO.User
{
    public class UserPagingVM : BasePagingVM
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }
    }
}

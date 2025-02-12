using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XGame.Entity
{
    [Index ( nameof ( UserName ), IsUnique = true )]
    public class UserEntity
    {

        [Key]
        public int ID { get; set; }


        [Required ( ErrorMessage = "این فیلد اجباریست" )]
        [MaxLength ( 100, ErrorMessage = "حداکثر 100 کاراکتر" )]
        [MinLength ( 5, ErrorMessage = "حداقال 5 کاراکتر باید باشد" )]
        [DisplayName ( "نام کاربری" )]
        public string? UserName { get; set; }

        [DisplayName ( "نام و نام خانوادگی" )]
        [Required ( ErrorMessage = "این فیلد اجباریست" )]
        [MaxLength ( 100, ErrorMessage = "حداکثر 100 کاراکتر" )]
        [MinLength ( 5, ErrorMessage = "حداقال 5 کاراکتر باید باشد" )]
        public string? FullName { get; set; }

        [DisplayName ( "آدرس ایمیل" )]
        [Required ( ErrorMessage = "این فیلد اجباریست" )]
        [MaxLength ( 100, ErrorMessage = "حداکثر 100 کاراکتر" )]
        [MinLength ( 5, ErrorMessage = "حداقال 5 کاراکتر باید باشد" )]
        public string? Email { get; set; }

        [DisplayName ( "تلفن همراه" )]
        [Required ( ErrorMessage = "این فیلد اجباریست" )]
        [MaxLength ( 15, ErrorMessage = "حداکثر 15 کاراکتر" )]
        [MinLength ( 5, ErrorMessage = "حداقال 5 کاراکتر باید باشد" )]
        public string? PhoneNumber { get; set; }

        [DisplayName ( "رمز عبور" )]
        [Required ( ErrorMessage = "این فیلد اجباریست" )]
        [MaxLength ( 100, ErrorMessage = "حداکثر 100 کاراکتر" )]
        [MinLength ( 5, ErrorMessage = "حداقال 5 کاراکتر باید باشد" )]
        public string? Password { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations;
using System;

namespace TdpLesson11.Models
{
    public class Student
    {
      
            public int Id { get; set; }

            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
            [StringLength(100, MinimumLength = 4,
                ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự.")]
            public string? Name { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "Vui lòng nhập email.")]
            [RegularExpression(
                @"^[A-Za-z0-9._%+-]+@gmail\.com$",
                ErrorMessage = "Email phải có đuôi @gmail.com.")]
            public string? Email { get; set; }

            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
            [StringLength(100, MinimumLength = 8,
                ErrorMessage = "Mật khẩu phải có từ 8 đến 100 ký tự.")]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,100}$",
                ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt.")]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Display(Name = "Ngành học")]
            [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
            public Branch? Branch { get; set; }

            [Display(Name = "Giới tính")]
            [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
            public Gender? Gender { get; set; }

            [Display(Name = "Hệ đào tạo")]
            public bool IsRegular { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
            public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Student), nameof(ValidateDateOfBirth))]
        public DateTime? DateOfBorth { get; set; }

        public static ValidationResult? ValidateDateOfBirth(
            DateTime? date,
            ValidationContext context)
        {
            if (date == null)
            {
                return ValidationResult.Success;
            }

            if (date.Value < new DateTime(1963, 1, 1) ||
                date.Value > new DateTime(2005, 12, 31))
            {
                return new ValidationResult(
                    "Ngày sinh phải từ năm 1963 đến hết năm 2005.");
            }

            return ValidationResult.Success;
        }

        [Display(Name = "Điểm")]
            [Required(ErrorMessage = "Vui lòng nhập điểm.")]
            [Range(0.0, 10.0,
                ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.")]
            public double? Score { get; set; }
    }
}



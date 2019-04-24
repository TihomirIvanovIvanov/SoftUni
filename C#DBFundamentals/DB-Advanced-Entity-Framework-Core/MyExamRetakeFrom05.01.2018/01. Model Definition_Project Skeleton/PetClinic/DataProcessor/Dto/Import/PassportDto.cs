using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor.Dto.Import
{
    public class PassportDto
    {
        [RegularExpression(@"^([A-Za-z]{7})+(\d{3})$")]
        public string SerialNumber { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [RegularExpression(@"^(\+359|0)+(\d{9})$")]
        public string OwnerPhoneNumber { get; set; }

        public string RegistrationDate { get; set; }
    }
}
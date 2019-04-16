
namespace EmailExercise.Model
{
    public class Settings
    {
        public static string MailAddressTo { get; set; } = "jobs@netpotential.co.nz, jcimafranca@gmail.com";
        public static string MailSubject { get; set; } = "An Email has been submitted from EmailExercise Online Form (For PracticalTest#1).";
        public static string MailHost { get; set; } = "smtp.webhost.co.nz"; //"smtp.gmail.com"; 
        public static int MailPort { get; set; } = 25;
        public static string SmtpUsername { get; set; } = "test@netpotential.co.nz";
        public static string SmtpPassword { get; set; } = "SmtP!2#4";
        public static bool EnableSsl { get; set; } = false;  //true; 


        public static string FullName { get; set; } = "<FullName>";
        public static string PhotoPath { get; set; } = "<PhotoPath>";
        public static string Email { get; set; } = "<Email>";
        public static string Mobile { get; set; } = "<Mobile>";
        public static string Message { get; set; } = "<Message>";

        public static string MailBody { get; set; } = $@"
        Hi there,
                
        A new email has been submitted. Please see below for the details.

        Name: {FullName}
        Photo URL: {PhotoPath}
        Email: {Email}
        Mobile: {Mobile}
        Message: {Message}

        Cheers,

        EmailExercise Online Form (ByJBC)";

        public static string ImageFolder { get; set; } = "avatar";

        public static string ThankYouMessage { get; set; } = "Thank you for sending us an email.";        
        public static string SampleFullName { get; set; } = "Enter your Full Name.";
        public static string SampleEmail { get; set; } = "example@myemail.com";
        public static string SampleMobile { get; set; } = "2108888888";
        public static string SampleMessage { get; set; } = "Enter your Message here.";
    }
}

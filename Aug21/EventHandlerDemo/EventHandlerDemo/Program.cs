using EventHandlerDemo;

public class Program1
{
    static void Main1()
    {
        Video video = new Video("Test");
        EmailService emailService = new EmailService();
        SMSService smsService = new SMSService();

        video.onVideoUploaded += emailService.SendEmail;
        video.onVideoUploaded += smsService.SendSMS;

        video.UploadVideo();
    }
}

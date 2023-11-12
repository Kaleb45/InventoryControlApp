using System.Net;
using System.Net.Mail;

public class EmailSender
{
    string sender = "a20300648@ceti.mx";
    string authKey = "laod bonq dwna dvap"; //Don't be an asshole, this auth key it's for my personal mail
                                            //We'll be using it until we decide how to solve this
    string smtpServer = "smtp.gmail.com";
    int port = 587;

    MailMessage message;
    SmtpClient smtpClient;
    public EmailSender()
	{
        message = new MailMessage();
        message.From = new MailAddress(sender);
        smtpClient = new SmtpClient(smtpServer)
        {
            Port = port,
            Credentials = new NetworkCredential(sender, authKey),
            EnableSsl = true
        };
    }

    public void setDestinatary(string destinatary)
    {
        message.To.Clear();
        message.To.Add(new MailAddress(destinatary));
    }

    public void addDestinatary(string destinatary)
    {
        message.To.Add(new MailAddress(destinatary));
    }

    public void setSubject(string subject)
    {
        message.Subject = subject;
    }

    public void setBody(string body, bool containsHTML)
    {
        message.Body = body;
        message.IsBodyHtml = containsHTML;
    }

    public void sendMail()
    {
        try
        {
            smtpClient.Send(message);
        }
        catch (Exception e) 
        { 
            Program.Fail("Couldn't send mail!");
            Program.Fail(e.Message);
        }
    }
}

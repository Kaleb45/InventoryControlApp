using System.Net;
using System.Net.Mail;

public class EmailSender
{
    string sender = "a20300648@ceti.mx"; //Sender mail, we don't have a "Warehouse" mail, we'll be using mine
                                         //(Stop sending mails to the teachers with my mail D:)
    string authKey = "laod bonq dwna dvap"; //Don't be an asshole, this auth key it's for my personal mail
                                            //We'll be using it until we decide how to solve this
    string smtpServer = "smtp.gmail.com"; //The smtp server from google
    int port = 587; //The port of the smtp server, duh

    MailMessage message; //Mail message object, required to send the mail
    SmtpClient smtpClient; //SmtpClient object, connects the program with the smtp server to be able to send mails


    /// <summary>
    /// Creates a new EmailSender object, you'll be able to set destinatary, a subject, the body  and send the mail
    /// </summary>
    public EmailSender()
	{
        message = new MailMessage(); //Initialize the MailMessage
        message.From = new MailAddress(sender); //Set Mail sender
        smtpClient = new SmtpClient(smtpServer) //Initialize the SMTPClient, assign info
        {
            Port = port,
            Credentials = new NetworkCredential(sender, authKey),
            EnableSsl = true
        };
    }

    /// <summary>
    /// Sets the recipient of the email, replacing existing recipients.
    /// </summary>
    /// <param name="destinatary">Recipient's email address.</param>
    public void setDestinatary(string destinatary)
    {
        message.To.Clear();
        message.To.Add(new MailAddress(destinatary));
    }

    /// <summary>
    /// Adds an additional recipient to the email.
    /// </summary>
    /// <param name="destinatary">Additional recipient's email address.</param>

    public void addDestinatary(string destinatary)
    {
        message.To.Add(new MailAddress(destinatary));
    }

    /// <summary>
    /// Sets the subject of the email.
    /// </summary>
    /// <param name="subject">Subject of the email.</param>
    public void setSubject(string subject)
    {
        message.Subject = subject;
    }

    /// <summary>
    /// Sets the body of the email and specifies whether the content is HTML.
    /// </summary>
    /// <param name="body">Body of the email.</param>
    /// <param name="containsHTML">Indicates whether the email body contains HTML formatting.</param>
    public void setBody(string body, bool containsHTML)
    {
        message.Body = body;
        message.IsBodyHtml = containsHTML;
    }

    /// <summary>
    /// Sets the body of the email and specifies whether the content is HTML.
    /// </summary>
    /// <param name="body">Body of the email.</param>
    /// <param name="containsHTML">Indicates whether the email body contains HTML formatting.</param>
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

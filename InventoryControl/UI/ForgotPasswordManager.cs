using AlmacenDataContext;
using AlmacenSQLiteEntities;
using System;
using System.Linq;

public static partial class UI
{
    public static void ForgotPassword()
    {
        Console.Clear();
        Console.WriteLine("Introduce tu correo electrónico:");
        string email = Console.ReadLine() ?? "";

        using (Almacen db = new Almacen())
        {
            Usuario usuario = db.Usuarios
                .FirstOrDefault(u => u.Almacenistas.Any(a => a.Correo == email)
                                   || u.Coordinadores.Any(c => c.Correo == email)
                                   || u.Docentes.Any(d => d.Correo == email)
                                   || u.Estudiantes.Any(e => e.Correo == email));

            if (usuario != null)
            {
                string verificationCode = GenerateRandomString();

                SendVerificationCodeByEmail(email, verificationCode);

                Console.WriteLine($"Se ha enviado un código de verificación a {email}.");
                Console.Write("Por favor, ingresa el código de verificación para poder cambiar su contraseña: ");
                string userEnteredCode = Console.ReadLine() ?? "";

                if (userEnteredCode == verificationCode)
                {
                    Console.WriteLine("Código de verificación correcto. Ahora puedes cambiar tu contraseña.");

                    string newPassword;
                    int validationCode;
                    do
                    {
                        Console.WriteLine("Ingresa tu nueva contraseña:");
                        newPassword = Console.ReadLine() ?? "";
                        validationCode = PasswordValidation(newPassword);

                        switch (validationCode)
                        {
                            case 10:
                                Console.WriteLine("Error: La contraseña debe tener al menos 8 caracteres.");
                                break;
                            case 20:
                                Console.WriteLine("Error: La contraseña debe contener por lo menos una mayúscula.");
                                break;
                            case 30:
                                Console.WriteLine("Error: La contraseña debe contener por lo menos un número.");
                                break;
                            case 40:
                                Console.WriteLine("Error: La contraseña debe contener por lo menos un caracter especial.");
                                break;
                            default:
                                break;
                        }
                    } while (validationCode != 01);

                    usuario.Password = newPassword;
                    db.SaveChanges();

                    Console.Clear();
                    Console.WriteLine("Tu contraseña se ha cambiado con éxito.");
                }
                else
                {
                    Console.WriteLine("Código de verificación incorrecto. No se puede cambiar la contraseña.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
    }

    private static string GenerateRandomString()
    {
        return Guid.NewGuid().ToString();
    }

    private static void SendVerificationCodeByEmail(string email, string verificationCode)
    {
        EmailSender emailSender = new EmailSender();
        emailSender.setDestinatary(email);
        emailSender.setSubject("Código de Verificación");
        emailSender.setBody($"Tu código de verificación es: {verificationCode}", containsHTML: false);
        emailSender.sendMail();
    }
}

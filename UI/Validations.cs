using System;
using InventoryControl;

public static partial class UI
{
    /// <summary>
    /// Username Validation Method for student
    /// 
    /// </summary>
    /// <param name="username"> Username string </param>
    /// <returns>
    ///     10 - Username Length isn't valid ||
    ///     20 - First two characters aren't a valid year ||
    ///     30 - The period is not a valid period ||
    ///     40 - The student ID is not a valid number ||
    ///     01 - The username is valid
    /// </returns>
    public static int UsernameValidation(string username)
    {
        if (username.Length > 50)
        {
            return 10;
        }
        if (int.TryParse(username, out _))
        {
            if (username.Length != 8)
            {

                return 10;
            }

            string year = username.Substring(0, 2);
            if (!int.TryParse(year, out _))
            {
                return 20;
            }

            string periodo = username.Substring(2, 3);
            if (periodo != "100" && periodo != "300")
            {
                return 30;
            }


            string identificador = username.Substring(5, 3);
            if (!int.TryParse(identificador, out _))
            {
                return 40;
            }
        }
        return 01;
    }

    /// <summary>
    /// Password Validation Method
    /// </summary>
    /// <param name="password"></param>
    /// <returns>
    ///     10 - Passsword is too short || 
    ///     20 - Password does not contains upper cases || 
    ///     30 - Password does not contains numbers || 
    ///     40 - Password does not contains special characters || 
    ///     01 - Password is valid
    /// </returns>
    public static int PasswordValidation(string password)
    {
        if (password.Length < 8)
        {
            return 10;
        }

        if (!password.Any(char.IsUpper))
        {
            return 20;
        }

        if (!password.Any(char.IsDigit))
        {
            return 30;
        }

        if (!password.Any(c => "!@#$%^&*()-_+=<>?".Contains(c)))
        {
            return 40;
        }

        return 01;
    }

    /// TODO:
    /// Docent Username Validations
    /// Almacenist Username Validations
    /// Administrator Username Validations
    /// Just length limitations
}
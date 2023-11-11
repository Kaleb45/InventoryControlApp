using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

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
            Console.WriteLine("La contraseña es muy corta");
            return 10;
        }

        if (!password.Any(char.IsUpper))
        {
            Console.WriteLine("La contraseña debe contener al menos un caracter en mayusculas");
            return 20;
        }

        if (!password.Any(char.IsDigit))
        {
            Console.WriteLine("La contraseña debe contener al menos un caracter numerico");
            return 30;
        }

        if (!password.Any(c => "!@#$%^&*()-_+=<>?".Contains(c)))
        {
            Console.WriteLine("La contraseña debe contener al menos un caracter especial");
            return 40;
        }

        return 01;
    }

    public static string GenerateUsername(string nombre, string ApellidoPaterno, string ApellidoMaterno)
    {
        string primerNombre = nombre.Split(' ')[0]; // Obtén el primer nombre
        string segundoNombre = string.Empty;
        if (nombre.Split(' ').Length > 1)
        {
            segundoNombre = nombre.Split(' ')[1][0].ToString(); // Obtiene la primera letra del segundo nombre si existe
        }
        string primerApellido = ApellidoPaterno;
        string segundoApellido = ApellidoMaterno[0].ToString(); // Obtén la primera letra del segundo apellido
        string username = $"{primerNombre}{segundoNombre}{primerApellido}{segundoApellido}";
        return username;
    }

    public static string SecondOptionUsername(string nombre, string ApellidoPaterno, string ApellidoMaterno)
    {
        string primerNombre = nombre.Split(' ')[0]; // Obtén el primer nombre
        string segundoNombre = string.Empty;
        if (nombre.Split(' ').Length > 1)
        {
            segundoNombre = nombre.Split(' ')[1][0].ToString(); // Obtiene la primera letra del segundo nombre si existe
        }
        string username = $"{primerNombre}{segundoNombre}{ApellidoPaterno}{ApellidoMaterno}";
        return username;
    }

    /// <summary>
    /// Register validation method
    /// </summary>
    /// <param name="registro"></param>
    /// <returns>
    ///     10 - wrong register length ||
    ///     20 - register cannot exist due to year ||
    ///     30 - register period is not valid  ||
    ///     01 -  register is valid ||
    /// </returns>
    public static int RegisterValidation(int registro)
    {
        string register = registro.ToString();
        if (register.Length != 8)//19300107
        {
            return 10;
        }
        int year = Convert.ToInt32(DateTime.Parse(DateTime.Now.ToString()).Year.ToString().Substring(2, 2));
        if ((registro / 1000000) > year)
        {
            return 20;
        }
        if (!register.Substring(2, 3).Contains("300") && !register.Substring(2, 3).Contains("100"))
        {
            return 30;
        }

        return 01;
    }

    /// <summary>
    /// Email Validation method
    /// </summary>
    /// <param name="Email"></param>
    /// <returns>
    ///         10 - wrong Email Length
    ///         20 - Not student email
    ///         30 - Wrong Email register
    ///         40 - Emails does not have "@ceti.mx"
    ///         01 - Valid Email ||
    /// </returns>
    public static int StudentEmailValidation(string? Email, long registro)
    {
        string register = registro.ToString();
        if (Email.Length != 17)//a19300107@ceti.mx
        {
            return 10;
        }
        if (!Email.Substring(0, 1).Contains('a'))
        {
            return 20;
        }
        if (!Email.Substring(1, 8).Contains(register))
        {
            return 30;
        }
        if (!Email.Substring(9, 8).Contains("@ceti.mx"))
        {
            return 40;
        }
        return 01;
    }

    /// <summary>
    /// Group Validation Method
    /// </summary>
    /// <param name="Grupo"></param>
    /// <returns></returns>
    public static int? GetGroupID(string? Grupo)
    {
        try
        {
            using (Almacen db = new())
            {
                Grupo Grupos = db.Grupos.First(g => g.Nombre == Grupo);
                if (Grupos is null)
                {
                    WriteLine("The value you were searching does not exists");
                    return 0;
                }
                else
                {
                    return Grupos.GrupoId;
                }
            }
        }
        catch (System.InvalidOperationException)
        {
            Program.Fail("Ese grupo no exite");
            return 0;
            throw;
        }
    }

/// <summary>
///     Verifies if group ID exists
/// </summary>
/// <param name="grupo"></param>
/// <returns>
///      10 - grupo no encontrado
///      01 - grupo encontrado    
/// </returns>
public static int GroupVerification(int grupo)
{
    using (Almacen db = new())
    {
        IQueryable<Grupo> Grupos = db.Grupos.Where(g => g.GrupoId == grupo);
        if (Grupos is null)
        {
            WriteLine("The value you were searching does not exists");
            return 10;
        }
        else
        {
            return 01;
        }
    }
}

public static bool NameValidation(string name)
{
    bool validName;
    if (name.Any(n => "!1234567890".Contains(n)) || name.Any(n => "!@#$%^&*()-_+=<>?".Contains(n)))
    {
        Console.WriteLine("No debe contener numeros o carcateres especiales");
        validName = false;
    }
    else
    {
        validName = true;
    }
    return validName;
}

public static bool EmailValidation(string email)
{
    bool validEmail;
    if (email.Contains("@ceti.mx") || email.Contains("@live.ceti.mx"))
    {
        validEmail = true;
    }
    else
    {
        Console.WriteLine("Correo electrónico invalido");
        validEmail = false;
    }
    return validEmail;
}

/// TODO:
/// Docent Username Validations
/// Almacenist Username Validations
/// Administrator Username Validations
/// Just length limitations
/// 
//Order validations:
public static bool DateValidation(string? sDate)
{
    bool validDate;
    try
    {
        if (DateTime.TryParse(sDate, out DateTime dateOnly))
        {
            if (dateOnly > DateTime.Now.Date && (dateOnly.Date - DateTime.Now.Date).TotalDays <= 7)
            {
                validDate = true;
            }
            else
            {
                validDate = false;
                Program.Fail("La fecha debe ser un día posterior al día actual y no mayor a una semana.");
            }
        }
        else
        {
            Program.Fail("Formato de fecha incorrecto. Intenta de nuevo.");
            validDate = false;
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Formato de fecha incorrecto. Intenta de nuevo.");
        validDate = false;
        throw;
    }
    return validDate;
}


public static int GetLabID(string? sLab)
{
    using (Almacen db = new())
    {
        try
        {
            Laboratorio laboratorio = db.Laboratorios.First(l => l.Nombre == sLab);
            if (laboratorio is null)
            {
                Program.Fail("Ese laboratorio no exite");
                return 0;
            }
            else
            {
                return laboratorio.LaboratorioId;
            }
        }
        catch (System.InvalidOperationException)
        {
            Program.Fail("Ese laboratorio no exite");
            return 0;
            throw;
        }
    }
}


public static bool LabValidation(int realLab)
{
    bool validLab;
    try
    {
        using (Almacen db = new())
        {
            IQueryable<Laboratorio> queryableLab = db.Laboratorios.Where(l => l.LaboratorioId == realLab);
            if (queryableLab is null || (!queryableLab.Any()))
            {
                Program.Fail("Ese laboratorio no exite");
                validLab = false;
            }
            else
            {
                validLab = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validLab = false;
        throw;
    }
    return validLab;
}
public static bool HourValidation(string? sHour)
{
    bool validHour;
    if (DateTime.TryParse(sHour, out DateTime hourOnly))
    {
        if (hourOnly.Hour < 7 || hourOnly.Hour > 14)
        {
            WriteLine("Horario no válido. Inténtalo de nuevo.");
            validHour = false;
        }
        else
        {
            validHour = true;
        }
    }
    else
    {
        Program.Fail("Formato de fecha incorrecto. Intenta de nuevo.");
        validHour = false;
    }
    return validHour;
}
}
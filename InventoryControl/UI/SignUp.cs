﻿using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class UI
{
    public static void SignUp()
    {
        int Registro;
        string? Nombre;
        int plantel;
        do
        {
            WriteLine("Ingresa tu registro");
        } while (int.TryParse(ReadLine(), out Registro) == false || RegisterValidation(Registro) != 01);

        do
        {
            WriteLine("Ingresa tu/s Nombre/s");
            Nombre = ReadLine();
        } while (NameValidation(Nombre) == false);

        WriteLine("Ingresa tu Apellido Paterno");
        string? ApellidoPaterno = ReadLine();
        while (NameValidation(ApellidoPaterno) == false)
        {
            ApellidoPaterno = ReadLine();
        }

        WriteLine("Ingresa tu Apellido Materno");
        string? ApellidoMaterno = ReadLine();
        while (NameValidation(ApellidoMaterno) == false)
        {
            ApellidoMaterno = ReadLine();
        }

        string newUsername = GenerateUsername(Nombre, ApellidoPaterno, ApellidoMaterno);

        
        do
        {
            WriteLine("Plantel: ");
            WriteLine("1. Colomos");
            WriteLine("2. Tonalá");
            WriteLine("3. Río Santiago");
            if (!int.TryParse(ReadLine(), out plantel))
            {
                WriteLine("Opción invalida");
            }
        } while (plantel < 1 || plantel > 3);

        WriteLine("Ingresa tu Semestre");
        int Semestre;
        while (int.TryParse(ReadLine(), out Semestre) == false || Semestre < 1 || Semestre > 8)
        {
            WriteLine("Caracteres invalidos en Semestre");
        }

        WriteLine("Ingresa tu Grupo");
        int Grupo;
        while (int.TryParse(ReadLine(), out Grupo) == false || Grupo < 1 || Grupo > 26)
        {
            WriteLine("Grupo no existente");
        }

        WriteLine("Ingesa tu correo");
        string? Correo = ReadLine();
        while (StudentEmailValidation(Correo, Registro) != 01)
        {
            WriteLine("Correo con formato incorrecto");
            Correo = ReadLine();
        }

        WriteLine("Ingresa tu contraseña");
        string? Contrasena = ReadLine();
        while (PasswordValidation(Contrasena) != 01)
        {
            WriteLine("Contraseña con formato incorrecto");
            Contrasena = ReadLine();
        }


        using (Almacen db = new Almacen())
        {
            var CheckStudent = db.Estudiantes.FirstOrDefault(r => r.EstudianteId == Registro || r.Correo == Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de usuario ya existentes");
                return;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;

            var usuario = new Usuario()
            {
                UsuarioId = UserID,
                Usuario1 = newUsername,
                Password = Contrasena,
            };

            var estudiante = new Estudiante()
            {
                EstudianteId = Registro,
                Nombre = Nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                PlantelId = plantel,
                SemestreId = Semestre,
                GrupoId = Grupo,
                Correo = Correo,
                UsuarioId = UserID,
            };

            Clear();
            db.Usuarios.Add(usuario);
            db.Estudiantes.Add(estudiante);
            db.SaveChanges();

        }
    }
    public static void SignUpDocente()
    {
       using (Almacen db = new Almacen()){
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int newId = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            string nombre;
            string ApellidoPaterno;
            string ApellidoMaterno;
            string correo;
            int plantel;
            string password;
            int validacionPassword;
            bool sameDocente = false;
            string newUsername;

            do{
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
            }while(!NameValidation(nombre));

            do{
                Console.Write("Apellido Paterno: ");
                ApellidoPaterno = Console.ReadLine();
            }while(!NameValidation(ApellidoPaterno));

            do{
                Console.Write("Apellido Materno: ");
                ApellidoMaterno = Console.ReadLine();
            }while(!NameValidation(ApellidoMaterno));

            newUsername = GenerateUsername(nombre, ApellidoPaterno, ApellidoMaterno);

            do{
                Console.Write("Correo: ");
                correo = Console.ReadLine();
                foreach(Docente docente in db.Docentes){
                    if(correo == docente.Correo){
                        Console.WriteLine("Usuario ya registrado");
                        sameDocente = true;
                    }
                    else{
                        foreach(Usuario usuario in db.Usuarios){
                            if(newUsername == usuario.Usuario1){
                                //En caso de que existan dos personas con el mismo nombre
                                newUsername = SecondOptionUsername(nombre, ApellidoPaterno, ApellidoMaterno);
                            }
                        }
                        sameDocente = false;
                    }
                }
            }while(!EmailValidation(correo) || sameDocente);

            do{
                Console.WriteLine("Plantel: ");
                Console.WriteLine("1. Colomos");
                Console.WriteLine("2. Tonalá");
                Console.WriteLine("3. Río Santiago");
                if(!int.TryParse(Console.ReadLine(), out plantel)){
                    Console.WriteLine("Opción invalida");
                }
                else{
                    plantel = int.Parse(Console.ReadLine());
                }

            }while(plantel < 1 || plantel > 3);
            
            do{
                Console.Write("Contraseña: ");
                password = Console.ReadLine();
                validacionPassword = PasswordValidation(password);
            }while(validacionPassword != 01);

            Usuario newUser = new Usuario
            {
                UsuarioId = newId,
                Usuario1 = newUsername,
                Password = password
            };

            int? lastDocenteId = db.Docentes.OrderByDescending(d => d.DocenteId).Select(d => d.DocenteId).FirstOrDefault();
            int newDocenteId = lastDocenteId.HasValue ? lastDocenteId.Value + 1 : 1;

            Docente newDocente = new Docente{
                DocenteId = newDocenteId,
                Nombre = nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                Correo = correo,
                PlantelId = plantel,
                UsuarioId = newId
            };

            db.Usuarios.Add(newUser);
            db.Docentes.Add(newDocente);
            db.SaveChanges();
            
       } 
    }

    public static void SignUpAlmacenista()
    {
       using (Almacen db = new Almacen()){
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int newId = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            string nombre;
            string ApellidoPaterno;
            string ApellidoMaterno;
            string correo;
            int plantel;
            string password;
            int validacionPassword;
            bool sameAlmacenista = false;
            string newUsername;

            do{
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
            }while(!NameValidation(nombre));

            do{
                Console.Write("Apellido Paterno: ");
                ApellidoPaterno = Console.ReadLine();
            }while(!NameValidation(ApellidoPaterno));

            do{
                Console.Write("Apellido Materno: ");
                ApellidoMaterno = Console.ReadLine();
            }while(!NameValidation(ApellidoMaterno));

            newUsername = GenerateUsername(nombre, ApellidoPaterno, ApellidoMaterno);

            do{
                Console.Write("Correo: ");
                correo = Console.ReadLine();
                foreach(Almacenista almacenista in db.Almacenistas){
                    if(correo == almacenista.Correo){
                        Console.WriteLine("Usuario ya registrado");
                        sameAlmacenista = true;
                    }
                    else{
                        foreach(Usuario usuario in db.Usuarios){
                            if(newUsername == usuario.Usuario1){
                                //En caso de que existan dos personas con el mismo nombre
                                newUsername = SecondOptionUsername(nombre, ApellidoPaterno, ApellidoMaterno);
                            }
                        }
                        sameAlmacenista = false;
                    }
                }
            }while(!EmailValidation(correo) || sameAlmacenista);

            do{
                Console.WriteLine("Plantel: ");
                Console.WriteLine("1. Colomos");
                Console.WriteLine("2. Tonalá");
                Console.WriteLine("3. Río Santiago");
                if(!int.TryParse(Console.ReadLine(), out plantel)){
                    Console.WriteLine("Opción invalida");
                }
                else{
                    plantel = int.Parse(Console.ReadLine());
                }

            }while(plantel < 1 || plantel > 3);
            
            do{
                Console.Write("Contraseña: ");
                password = Console.ReadLine();
                validacionPassword = PasswordValidation(password);
            }while(validacionPassword != 01);

            Usuario newUser = new Usuario
            {
                UsuarioId = newId,
                Usuario1 = newUsername,
                Password = password
            };

            int? lastAlmacenistaId = db.Almacenistas.OrderByDescending(a => a.AlmacenistaId).Select(a => a.AlmacenistaId).FirstOrDefault();
            int newAlmacenistaId = lastAlmacenistaId.HasValue ? lastAlmacenistaId.Value + 1 : 1;

            Almacenista newAlmacenista = new Almacenista{
                AlmacenistaId = newAlmacenistaId,
                Nombre = nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                Correo = correo,
                PlantelId = plantel,
                UsuarioId = newId
            };

            db.Usuarios.Add(newUser);
            db.Almacenistas.Add(newAlmacenista);
            db.SaveChanges();
            
       } 
    }
}
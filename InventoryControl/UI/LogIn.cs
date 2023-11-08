using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class UI
{
    
    /// <summary>
    /// Metodo de login , revisa si existe ese usuario en la bd y retorna su tipo y usuario encontrado
    /// </summary>
    /// <param name="usuarioEncontrado">Usuario que encontro segun las credenciales</param>
    /// <param name="userName">usuario</param>
    /// <param name="password">contraseña</param>
    /// <returns></returns>
    static (Usuario? usuarioEncontrado,int typeOfUser) LogIn(string userName,string password){
        using (Almacen db = new()){
            var user = db.Usuarios.FirstOrDefault(u => u.Usuario1 == userName && u.Password == password);//busca al usuario en la BD 
            //si no es nulo , osea que si encontro un usuario regresara al usuario encontrado junto con su tipo
            if (user != null){
                Console.Clear();
                Console.WriteLine($"¡Bienvenido, {userName}!");
                Console.WriteLine("");
                int TipoUsuario=0;
                if (user.Docentes.Any()){
                    TipoUsuario=1;
                }
                else if (user.Estudiantes.Any()){
                    TipoUsuario=2;
                }
                else if (user.Almacenistas.Any()){
                    TipoUsuario=3;
                }
                else if (user.Coordinadores.Any()){
                    TipoUsuario=4;
                }
                return (user,TipoUsuario);
            }
            else{
                Console.Clear();
                Console.WriteLine("Usuario o contraseña incorrectos. Inténtalo nuevamente.");
                return (user,0);
            }
        }
    }

    /// <summary>
    /// Metodo que segun el tipo de usuario encontrado desplegara el menu correspondiente 
    /// </summary>
    /// <param name="typeOfUser">tipo de usuario 1,2,3,4</param> <summary>
    /// 
    /// </summary>
    /// <param name="typeOfUser"></param>
    static public void MenuSelected(int typeOfUser, int userID){
        using(Almacen db = new()){
            switch(typeOfUser){
            case 1:
                Docente? docente = db.Docentes!.FirstOrDefault(p => p.UsuarioId == userID);
                TeacherUI(docente);
                break;
            case 2:
                Estudiante? estudiante = db.Estudiantes!.FirstOrDefault(p => p.UsuarioId == userID);
                StudentUI(estudiante);
                break;
            case 3:
                Almacenista? almacenista = db.Almacenistas!.FirstOrDefault(p => p.UsuarioId == userID);
                InventoryManagerUI(almacenista);
                break;
            case 4:
                Coordinador? coordinador = db.Coordinadores!.FirstOrDefault(p => p.UsuarioId == userID);
                AdministratorUI(coordinador);
            break;
        }
        }
    }
}

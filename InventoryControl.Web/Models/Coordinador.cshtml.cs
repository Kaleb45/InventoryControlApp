using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using AlmacenSQLiteEntities;
using AlmacenDataContext;

namespace InventoryControlPages
{
    public class CoordinadorModel : PageModel
    {
        private Almacen db;

        public CoordinadorModel(Almacen context)
        {
            db = context;
        }

        public List<Coordinador>? coordinadores { get; set; }

        [BindProperty]
        public Coordinador? coordinador { get; set; }

        [BindProperty]
        public Pedido? pedido { get; set; }

        [BindProperty]
        public DescPedido? descPedido { get; set; }

        [BindProperty]
        public Categoria? categoria { get; set; }

        [BindProperty]
        public Material? material { get; set; }

        [BindProperty]
        public Marca? marca { get; set; }

        [BindProperty]
        public Modelo? modelo { get; set; }
        [BindProperty]
        public Usuario? usuario { get; set; }
        [BindProperty]
        public Estudiante? estudiante {get; set;}
        [BindProperty]
        public Docente? docente {get; set;}
        [BindProperty]
        public Almacenista? almacenista { get; set; }

        public void OnGet(int id)
        {
            coordinador = db.Coordinadores.FirstOrDefault(a => a.CoordinadorId == id);
            ViewData["Title"] = "";
            TempData["UserType"] = 4;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
            }
            
            return Page();
        }

        public IActionResult OnPostApprove()
        {
            // Obtener el valor de pedidoId del formulario
            pedido = db.Pedidos.FirstOrDefault(p => p.PedidoId == int.Parse(Request.Form["pedidoId"]));
            pedido.Estado = true;
            Estudiante estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == pedido.EstudianteId);
            UI.SendEmailForOrderState(estudiante,"Datos incorrectos",pedido);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostDecline()
        {
            // Obtener el valor de pedidoId del formulario            
            pedido = db.Pedidos.FirstOrDefault(p => p.PedidoId == int.Parse(Request.Form["pedidoId"]));
            pedido.Estado = false;
            descPedido = db.DescPedidos.FirstOrDefault(p => p.PedidoId == pedido.PedidoId);
            Estudiante estudiante = db.Estudiantes.FirstOrDefault(e => e.EstudianteId == pedido.EstudianteId);
            UI.SendEmailForOrderState(estudiante,"Datos incorrectos",pedido);
            db.DescPedidos.RemoveRange(descPedido);
            db.Pedidos.RemoveRange(pedido);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostNewCat()
        {
            // Obtener el valor de pedidoId del formulario  
            if ((categoria is not null) &&  !ModelState.IsValid)
            {
                CrudFuntions.AddCategoria(categoria);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }

        public IActionResult OnPostNewMarca()
        {
            // Obtener el valor de pedidoId del formulario  
            if ((marca is not null) &&  !ModelState.IsValid)
            {
                CrudFuntions.AddMarca(marca);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }

        public IActionResult OnPostNewModelo()
        {
            // Obtener el valor de pedidoId del formulario  
            if ((modelo is not null) &&  !ModelState.IsValid)
            {
                CrudFuntions.AddModelo(modelo);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }
        public IActionResult OnPostNewMaterial()
        {
            // Obtener el valor de pedidoId del formulario  
            if ((material is not null) &&  !ModelState.IsValid)
            {
                CrudFuntions.AddMaterial(material);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }

        public IActionResult OnPostNewEstudiante()
        {
            if ((estudiante is not null) && !ModelState.IsValid)
            {
                int validationRegister = UI.RegisterValidation(estudiante.EstudianteId);

                switch (validationRegister)
                {
                    case 10:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 20:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 30:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }
                
                int validationEmail = UI.StudentEmailValidation(estudiante.Correo, estudiante.EstudianteId);

                switch (validationEmail)
                {
                    case 10:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 20:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 30:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 40:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 50:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 70:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 80:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 100:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                int validationPassword = UI.PasswordValidation(usuario.Password);
                
                switch (validationPassword)
                {
                    case 10:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 20:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 30:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 40:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 50:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 80:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 90:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 100:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                estudiante.Adeudo = 0;
                usuario.Temporal = false;
                usuario.Usuario1 = UI.GenerateUsername(estudiante.Nombre, estudiante.ApellidoPaterno, estudiante.ApellidoMaterno);
                TempData["UserName"] = usuario.Usuario1;
                CrudFuntions.AddStudent(estudiante, usuario);
                //UI.NotificationUserName(estudiante);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }
        public IActionResult OnPostNewDocente()
        {
            if ((estudiante is not null) && !ModelState.IsValid)
            {
                if(!UI.EmailValidation(docente.Correo)){
                    return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                }

                int validationPassword = UI.PasswordValidation(usuario.Password);
                
                switch (validationPassword)
                {
                    case 10:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 20:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 30:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 40:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 50:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 80:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 90:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 100:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                usuario.Temporal = false;
                usuario.Usuario1 = UI.GenerateUsername(docente.Nombre, docente.ApellidoPaterno, docente.ApellidoMaterno);
                TempData["UserName"] = usuario.Usuario1;
                CrudFuntions.AddTeacher(docente, usuario);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }
        
        public IActionResult OnPostNewAlmacenista()
        {
            if ((estudiante is not null) && !ModelState.IsValid)
            {
                if(!UI.EmailValidation(almacenista.Correo)){
                    return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                }

                int validationPassword = UI.PasswordValidation(usuario.Password);
                
                switch (validationPassword)
                {
                    case 10:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 20:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 30:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 40:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 50:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 80:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 90:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 100:
                        return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
                    case 01:
                        // No hay error, proceder con la lógica normal
                        break;
                }

                usuario.Temporal = false;
                usuario.Usuario1 = UI.GenerateUsername(almacenista.Nombre, almacenista.ApellidoPaterno, almacenista.ApellidoMaterno);
                TempData["UserName"] = usuario.Usuario1;
                CrudFuntions.AddWarehouseManager(almacenista, usuario);
                TempData["UserType"] = 4;
                return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
            }
            return Page();
        }

        public IActionResult OnPostDeleteOrder()
        {
            // Obtener el valor de pedidoId del formulario            
            pedido = db.Pedidos.FirstOrDefault(p => p.PedidoId == int.Parse(Request.Form["pedidoId"]));
            descPedido = db.DescPedidos.FirstOrDefault(p => p.PedidoId == pedido.PedidoId);
            db.DescPedidos.RemoveRange(descPedido);
            db.Pedidos.RemoveRange(pedido);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostDeleteCategoria()
        {
            // Obtener el valor de pedidoId del formulario            
            categoria = db.Categorias.FirstOrDefault(p => p.CategoriaId == int.Parse(Request.Form["categoriaId"]));
            foreach (var material in db.Materiales)
            {
                if(material.CategoriaId == int.Parse(Request.Form["categoriaId"])){
                    db.Materiales.RemoveRange(material);
                }
            }
            db.Categorias.RemoveRange(categoria);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostDeleteModelo()
        {
            // Obtener el valor de pedidoId del formulario            
            modelo = db.Modelos.FirstOrDefault(p => p.ModeloId == int.Parse(Request.Form["modeloId"]));
            foreach (var material in db.Materiales)
            {
                if(material.ModeloId == int.Parse(Request.Form["modeloId"])){
                    db.Materiales.RemoveRange(material);
                }
            }
            db.Modelos.RemoveRange(modelo);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostDeleteMarca()
        {
            // Obtener el valor de pedidoId del formulario            
            marca = db.Marcas.FirstOrDefault(p => p.MarcaId == int.Parse(Request.Form["marcaId"]));
            foreach (var material in db.Materiales)
            {
                if(material.MarcaId == int.Parse(Request.Form["marcaId"])){
                    db.Materiales.RemoveRange(material);
                }
            }
            db.Marcas.RemoveRange(marca);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostDeleteMaterial()
        {
            // Obtener el valor de pedidoId del formulario            
            material = db.Materiales.FirstOrDefault(p => p.MaterialId == int.Parse(Request.Form["materialId"]));
            db.Materiales.RemoveRange(material);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }
        
        public IActionResult OnPostDeleteEstudiante()
        {
            // Obtener el valor de estudianteId del formulario            
            estudiante = db.Estudiantes.FirstOrDefault(p => p.EstudianteId == int.Parse(Request.Form["estudianteId"]));
            // Obtener los pedidos y desc_pedidos asociados al estudiante
            IQueryable<Pedido> pedidos = db.Pedidos!.Where(p => p.EstudianteId == estudiante.EstudianteId);
            IQueryable<DescPedido> descPedidos = db.DescPedidos!.Where(dp => pedidos.Any(p => p.PedidoId == dp.PedidoId));

            // Eliminar los desc_pedidos asociados
            db.DescPedidos.RemoveRange(descPedidos);

            // Eliminar los pedidos asociados
            db.Pedidos.RemoveRange(pedidos);

            // Eliminar el usuario asociado al estudiante
            db.Usuarios.RemoveRange(estudiante.Usuario);

            // Eliminar al estudiante
            db.Estudiantes.RemoveRange(estudiante);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }
        
        public IActionResult OnPostDeleteDocente()
        {
            // Obtener el valor de estudianteId del formulario            
            docente = db.Docentes.FirstOrDefault(p => p.DocenteId == int.Parse(Request.Form["docenteId"]));
            // Obtener los pedidos y desc_pedidos asociados al estudiante
            IQueryable<Pedido> pedidos = db.Pedidos!.Where(p => p.DocenteId == docente.DocenteId);
            IQueryable<DescPedido> descPedidos = db.DescPedidos!.Where(dp => pedidos.Any(p => p.PedidoId == dp.PedidoId));

            // Eliminar los desc_pedidos asociados
            db.DescPedidos.RemoveRange(descPedidos);

            // Eliminar los pedidos asociados
            db.Pedidos.RemoveRange(pedidos);

            // Eliminar el usuario asociado al estudiante
            db.Usuarios.RemoveRange(docente.Usuario);

            // Eliminar al estudiante
            db.Docentes.RemoveRange(docente);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }
        
        public IActionResult OnPostDeleteAlmacenista()
        {
            // Obtener el valor de estudianteId del formulario            
            almacenista = db.Almacenistas.FirstOrDefault(p => p.AlmacenistaId == int.Parse(Request.Form["almacenistaId"]));

            // Eliminar el usuario asociado al estudiante
            db.Usuarios.RemoveRange(almacenista.Usuario);

            // Eliminar al estudiante
            db.Almacenistas.RemoveRange(almacenista);
            db.SaveChanges();
            TempData["UserType"] = 4;
            return RedirectToPage("/CoordinadorMenu", new{id = int.Parse(Request.Form["coordinadorId"])});
        }

        public IActionResult OnPostUpdate()
        {
            // Obtener el valor de pedidoId del formulario  
            int registroId = int.Parse(Request.Form["registroId"]);
            string tableId = Request.Form["tableId"];
            int userId = int.Parse(Request.Form["coordinadorId"]);
            string typeUser = "Coordinador";
            return RedirectToPage("/Updates", new{id = registroId, table = tableId, usuario = userId, tipo = typeUser});
        }
    }
}

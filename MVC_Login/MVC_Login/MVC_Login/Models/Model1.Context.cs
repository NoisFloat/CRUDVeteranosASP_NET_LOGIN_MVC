﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Login.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DarwinGodEntities10 : DbContext
    {
        public DarwinGodEntities10()
            : base("name=DarwinGodEntities10")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DonativosAlimentacion> DonativosAlimentacions { get; set; }
        public virtual DbSet<DonativosDinero> DonativosDineroes { get; set; }
        public virtual DbSet<DonativosProductosPersonale> DonativosProductosPersonales { get; set; }
        public virtual DbSet<Roles_Usuario> Roles_Usuario { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual ObjectResult<ConsultarInformacioUsuario_Result> ConsultarInformacioUsuario(string correo)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarInformacioUsuario_Result>("ConsultarInformacioUsuario", correoParameter);
        }
    
        public virtual ObjectResult<ConsultarUsuariosConDonativos_Result> ConsultarUsuariosConDonativos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarUsuariosConDonativos_Result>("ConsultarUsuariosConDonativos");
        }
    
        public virtual int EliminarUsuarioYDonativos(string correoUsuario)
        {
            var correoUsuarioParameter = correoUsuario != null ?
                new ObjectParameter("correoUsuario", correoUsuario) :
                new ObjectParameter("correoUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarUsuarioYDonativos", correoUsuarioParameter);
        }
    
        public virtual ObjectResult<ObtenerDonativosPorCorreoTodosLosBeneficios_Result> ObtenerDonativosPorCorreoTodosLosBeneficios(string correoUsuario)
        {
            var correoUsuarioParameter = correoUsuario != null ?
                new ObjectParameter("correoUsuario", correoUsuario) :
                new ObjectParameter("correoUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerDonativosPorCorreoTodosLosBeneficios_Result>("ObtenerDonativosPorCorreoTodosLosBeneficios", correoUsuarioParameter);
        }
    
        public virtual ObjectResult<ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente_Result> ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente(string correoUsuario)
        {
            var correoUsuarioParameter = correoUsuario != null ?
                new ObjectParameter("correoUsuario", correoUsuario) :
                new ObjectParameter("correoUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente_Result>("ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente", correoUsuarioParameter);
        }
    
        public virtual ObjectResult<ObtenerUsuarioPorCorreoYPassword_Result> ObtenerUsuarioPorCorreoYPassword(string correo, string password)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerUsuarioPorCorreoYPassword_Result>("ObtenerUsuarioPorCorreoYPassword", correoParameter, passwordParameter);
        }
    
        public virtual int sp_ActualizarUsuario(string correo, string nombres, string apellidos, string password_usuario, string direccion_residencia, Nullable<bool> estado_extranjero)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("nombres", nombres) :
                new ObjectParameter("nombres", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var password_usuarioParameter = password_usuario != null ?
                new ObjectParameter("password_usuario", password_usuario) :
                new ObjectParameter("password_usuario", typeof(string));
    
            var direccion_residenciaParameter = direccion_residencia != null ?
                new ObjectParameter("direccion_residencia", direccion_residencia) :
                new ObjectParameter("direccion_residencia", typeof(string));
    
            var estado_extranjeroParameter = estado_extranjero.HasValue ?
                new ObjectParameter("estado_extranjero", estado_extranjero) :
                new ObjectParameter("estado_extranjero", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarUsuario", correoParameter, nombresParameter, apellidosParameter, password_usuarioParameter, direccion_residenciaParameter, estado_extranjeroParameter);
        }
    }
}

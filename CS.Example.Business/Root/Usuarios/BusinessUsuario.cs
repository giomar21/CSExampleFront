using CS.Example.Business.Interfaces.Usuarios;
using CS.Example.Common;
using CS.Example.Common.Models;
using CS.Example.Communication.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Business.Root.Usuarios
{
    public class BusinessUsuario : IBusinessUsuario
    {
        public BusinessUsuario()
        {

        }

        public async Task<OperationResult> Delete(Guid idUsuario)
        {
            var result = new OperationResult();

            try
            {
                await UsuariosService.DeleteUsuario(idUsuario);
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al obtener listado de Usuarios: {ex.Message}");
            }
        }

        public async Task<OperationResult<UsuarioModel>> Get(int initRow, int finishRow, string? word)
        {
            var result = new OperationResult<UsuarioModel>();

            try
            {
                var rUsuarios = await UsuariosService.GetUsuarios(initRow, finishRow, word);
                result.Data = rUsuarios;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al obtener listado de Usuarios: {ex.Message}");
            }
        }

        public async Task<OperationResult<Usuario?>> Post(Usuario usuario)
        {
            var result = new OperationResult<Usuario>();

            try
            {
                var rUsuario = await UsuariosService.CreateUsuario(usuario);
                result.Data = rUsuario;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al registrar el usuario: {ex.Message}");
            }
        }

        public async Task<OperationResult<Usuario?>> Put(Usuario usuario)
        {
            var result = new OperationResult<Usuario>();

            try
            {
                var rUsuario = await UsuariosService.UpdateUsuario(usuario);
                result.Data = rUsuario;
                return result.ToSuccess();
            }
            catch (Exception ex)
            {
                return result.ToError($"Error al actualizar el usuario: {ex.Message}");
            }
        }
    }
}

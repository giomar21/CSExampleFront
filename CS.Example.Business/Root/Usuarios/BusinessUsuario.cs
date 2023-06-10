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

        public Task<OperationResult> Delete(Guid idUsuario)
        {
            throw new NotImplementedException();
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

        public Task<OperationResult<Usuario?>> Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}

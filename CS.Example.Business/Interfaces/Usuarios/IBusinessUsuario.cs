using CS.Example.Common;
using CS.Example.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Business.Interfaces.Usuarios
{
    public interface IBusinessUsuario
    {
        Task<OperationResult<UsuarioModel>> Get(int initRow, int finishRow, string? word);
    }
}

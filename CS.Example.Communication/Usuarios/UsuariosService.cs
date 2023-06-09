using CS.Example.Common.Constants;
using CS.Example.Common.HttpHelpers;
using CS.Example.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Communication.Usuarios
{
    public static class UsuariosService
    {
        private static bool isInitialized;
        private static string URL_BASE;

        /// <summary>
        /// Inicializa la configuración para solcitudes a la API de Usuarios
        /// </summary>
        /// <param name="url_base"></param>
        public static void Init(string url_base)
        {
            if (isInitialized) return;

            URL_BASE = url_base;

            isInitialized = true;
        }

        /// <summary>
        /// Servicio que devuelve un objeto de tipo <see cref="UsuarioModel"/> con la lista de usuarios solicitados según el filtro de entrada
        /// </summary>
        /// <param name="initRow"></param>
        /// <param name="finishRow"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static async Task<UsuarioModel> GetUsuarios(int initRow, int finishRow, string? word)
        {
            string urlRequest = $"{URL_BASE}/Usuario?initRow={initRow}&finishRow={finishRow}&word={word}";

            var headers = new Dictionary<string, string>() {
                { "Content-Type", ContentType.JSON }
            };

            UsuarioModel rRquest = await RestClientHelper.JsonRequest<UsuarioModel, string>(string.Empty, urlRequest, ContentType.JSON, HttpMethods.Get, headers);

            return rRquest;
        }
    }
}

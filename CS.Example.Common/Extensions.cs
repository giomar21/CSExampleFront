using CS.Example.Common.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Establece un OperationResult como éxito
        /// Se puede incluir un mensaje de forma opcional 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static dynamic ToSuccess(this IOperationResult op, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg)) op.Message = msg;
            op.Success = true;
            return op;
        }

        /// <summary>
        /// Establece un OperationResult como error
        /// Se puede incluir un mensaje de forma opcional 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static dynamic ToError(this IOperationResult op, string msg = "")
        {
            if (!string.IsNullOrEmpty(msg)) op.Message = msg;
            //Logger.Debug(msg);
            op.Success = false;
            return op;
        }

        /// <summary>
        /// Copia los valores del objeto origen al objeto destino, retornando el objeto destino.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static dynamic GetValues(this IOperationResult op, IOperationResult source)
        {
            op.Message = source.Message;
            op.Success = source.Success;
            //Logger.Debug(source.Message);
            return op;
        }

        /// <summary>
        /// Convierte las propiedades de un objecto a un Diccionario
        /// </summary>
        /// <param name="op"></param>
        /// <returns>IDictionary</returns>

        public static IDictionary<string, string> ToDict(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            JToken token = obj as JToken;
            if (token == null)
            {
                return ToDict(JObject.FromObject(obj));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToDict();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                            .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                jValue?.ToString("o", CultureInfo.CurrentCulture) :
                jValue?.ToString(CultureInfo.CurrentCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}

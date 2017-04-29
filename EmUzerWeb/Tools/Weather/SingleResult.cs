using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmUzerWeb.Tools.Weather
{
    public struct SingleResult<T>
    {
        /// <summary>
        ///     Generic Result class constructor for single result
        /// </summary>
        /// <param name="item">item to return</param>
        /// <param name="success">status of operation</param>
        /// <param name="message">possilbe error message</param>
        public SingleResult(T item, Boolean success, String message)
            : this()
        {
            Item = item;
            Success = success;
            Message = message;
        }

        /// <summary>
        ///     Result items.
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        ///     Operation result message.
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        ///     Operation result status.
        /// </summary>
        public Boolean Success { get; set; }
    }

    
}
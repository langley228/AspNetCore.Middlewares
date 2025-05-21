using System;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Middlewares
{
    /// <summary>
    /// ���� HttpContext �������X�R��k�C
    /// </summary>
    internal static class HttpContextExtensions
    {
        /// <summary>
        /// �P�_�t�άO�_�B����@�Ҧ��C
        /// �z�L�ˬd�����ܼ� "IsMaintenance" �O�_�� "1" �ӨM�w�C
        /// �Y�� "1" �h��ܨt�ζi�J���@���A�A�_�h�����`���A�C
        /// </summary>
        /// <param name="context">HTTP �ШD���e�C</param>
        /// <returns>�Y�����@�Ҧ��h�^�� true�A�_�h�^�� false�C</returns>
        public static bool IsMaintenance(this HttpContext context)
        {
            return Environment.GetEnvironmentVariable("IsMaintenance") == "1";
        }
    }
}

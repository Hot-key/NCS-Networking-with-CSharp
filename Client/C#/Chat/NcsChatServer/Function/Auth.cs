using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace NcsChatServer.Function
{
    public static class Auth
    {
        public static string StringToHash(string data)
        {
            return HashGenerator.ComputeSha512Hash
            (
                HashGenerator.ComputeSha256Hash
                (
                    HashGenerator.ComputeSha256Hash
                    (
                        Convert.ToBase64String
                        (
                            Encoding.UTF8.GetBytes(data + data.Length.ToString())
                        )
                    )
                )
            );
        }
    }
}

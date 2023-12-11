using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Text;

namespace apiBt1.Models
{
    public class Text
    {
        public int Id { get; set; }
        public string Content { get; set; }

        //internal void Restore(FileStream stream)
        //{
        //    //int --> 4 byte.
        //    var bytes_id = new byte[4];
        //    stream.Read(bytes_id, 0, 4);
        //    Id = BitConverter.ToInt32(bytes_id, 0);

        //    //Chuoi content
        //    var bytes_content_leng = new byte[4];
        //    stream.Read(bytes_content_leng, 0, 4);
        //    int leng = BitConverter.ToInt32(bytes_content_leng, 0);

        //    var bytes_content = new byte[leng];
        //    stream.Read(bytes_content, 0, leng);
        //    Content = Encoding.UTF8.GetString(bytes_content, 0, leng);
        //}

        //internal void Save(FileStream stream)
        //{
        //    //int --> 4 byte.
        //    var bytes_id = BitConverter.GetBytes(Id);
        //    stream.Write(bytes_id, 0, 4);

        //    //chuoi content.
        //    var bytes_content = Encoding.UTF8.GetBytes(Content);
        //    var bytes_content_leng = BitConverter.GetBytes(bytes_content.Length);
        //    stream.Write(bytes_content_leng, 0, 4);
        //    stream.Write(bytes_content, 0, bytes_content.Length);
        //}
    }
}

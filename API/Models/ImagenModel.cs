using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ImagenModel
    {
        private static string save;
        public ImagenModel() { }

        public ImagenModel(string image)
        {
            save = image;
        }

        public string getIamge()
        {
            return save;
        }

    }
}
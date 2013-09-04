using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class Party
    {
        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_logo;

        public string Logo
        {
            get { return m_logo; }
            set { m_logo = value; }
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_web;

        public string Web
        {
            get { return m_web; }
            set { m_web = value; }
        }

    }
}

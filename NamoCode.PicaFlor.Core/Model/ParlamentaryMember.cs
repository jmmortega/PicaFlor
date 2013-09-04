using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class ParlamentaryMember
    {
        private string m_avatar;

        public string Avatar
        {
            get { return m_avatar; }
            set { m_avatar = value; }
        }

        private int m_congressId;

        public int CongressId
        {
            get { return m_congressId; }
            set { m_congressId = value; }
        }

        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_congressWeb;

        public string CongressWeb
        {
            get { return m_congressWeb; }
            set { m_congressWeb = value; }
        }

        private string m_division;

        public string Division
        {
            get { return m_division; }
            set { m_division = value; }
        }

        private string m_mail;

        public string Email
        {
            get { return m_mail; }
            set { m_mail = value; }
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_lastName;

        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }
        
        public string FullName
        {
            get 
            {
                return string.Format("{0} {1}", new object[] { m_name, m_lastName });
            }            
        }
        
        private string m_twitter;

        public string Twitter
        {
            get { return m_twitter; }
            set { m_twitter = value; }
        }

        private string m_web;

        public string Web
        {
            get { return m_web; }
            set { m_web = value; }
        }


    }
}
